using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Luna.Commons.Models;
using Luna.Commons.Models.Dtos;
using Luna.Commons.Repositories.Implementations;
using Luna.Commons.Services;
using Luna.Mvc;
using Luna.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace Luna.Controllers
{
    public class CharacterController : BaseController
    {
        private CharacterRepository _characterRepository { get; set; }
        private CharacterRepository CharacterRepository =>
            _characterRepository ??= _scope.Resolve<CharacterRepository>();
        
        private RaceRepository _raceRepository { get; set; }
        private RaceRepository RaceRepository =>
            _raceRepository ??= _scope.Resolve<RaceRepository>();
        
        private CharacterTypeRepository _characterTypeRepository { get; set; }
        private CharacterTypeRepository CharacterTypeRepository =>
            _characterTypeRepository ??= _scope.Resolve<CharacterTypeRepository>();
        
        private CustomPropertyTypeRepository _CustomPropertyTypeRepository { get; set; }
        private CustomPropertyTypeRepository CustomPropertyTypeRepository =>
            _CustomPropertyTypeRepository ??= _scope.Resolve<CustomPropertyTypeRepository>();
        
        private CurrentUserAccessor _cua { get; set; }
        private CurrentUserAccessor CurrentUserAccessor => _cua ??= _scope.Resolve<CurrentUserAccessor>();
        
        public CharacterController(ILifetimeScope scope) : base(scope)
        {
        }

        public async Task<IActionResult> Index()
        {
            var characters = await CharacterRepository.GetAll();
            
            return View(characters.Select(_ => new CharacterDto(_)));
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CharacterDto model)
        {
            var currentUserId = await CurrentUserAccessor.GetUserId();

            // On crée d'abord le personnage avec juste son type et sa race
            var item = model.ToSimpleModel(currentUserId);
            item.TypeId = model.Type.Id.Value;
            item.RaceId = model.Race.Id.Value;
            var character = await CharacterRepository.Insert(item);

            // Et on update ensuite pour lui rajouter toutes ses propriétés custom
            item = model.ToModel(currentUserId);
            item.Id = character.Id;

            await CharacterRepository.Update(item);

            return Ok(Url.Action("Edit", "Character", new { id = item.Id }));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            return View(id);
        }

        [HttpGet]
        public async Task<IActionResult> GetCharacterById(int id)
        {
            var character = await CharacterRepository.GetFullCharacterById(id);

            if (character == null)
            {
                return NotFound();
            }
            
            return Ok(new CharacterDto(character));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CharacterDto model)
        {
            if (!model.Id.HasValue)
            {
                return RedirectToAction("Index");
            }

            var currentUserId = await CurrentUserAccessor.GetUserId();

            var character = await CharacterRepository.GetFullCharacterById(model.Id.Value);

            character.Name = model.Name;
            character.Description = model.Description;
            character.TypeId = model.Type.ToModel(currentUserId).Id;
            character.RaceId = model.Race.ToModel(currentUserId).Id;

            // Sections
            await UpdateSections(model.CustomSections, character.CustomSections, character.Id, currentUserId);

            return Ok(Url.Action("Index", "Character"));
        }

        private async Task UpdateSections(IEnumerable<CustomSectionDto> sectionDtos, IEnumerable<CustomSection> characterSections, int characterId, Guid currentUserId)
        {
            var listSectionDtos = sectionDtos?.ToList();
            var listCharacterSections = characterSections?.ToList();
            
            if (listSectionDtos?.Any() != true)
            {
                if (listCharacterSections?.Any() == true)
                {
                    await CharacterRepository.DeleteSectionsWithProperties(listCharacterSections);
                }
                
                return;
            }

            var sectionIds = new List<int>();

            foreach (var modelCustomSection in listSectionDtos)
            {
                CustomSection customSection = null;

                // Si on a un Id, on essaye de récupérer la section dans le perso
                if (modelCustomSection.Id.HasValue)
                {
                    customSection = listCharacterSections?.FirstOrDefault(_ => _.Id == modelCustomSection.Id.Value);

                    if (customSection != null)
                    {
                        var cs = modelCustomSection.ToModel(currentUserId);

                        customSection.Name = cs.Name;
                        customSection.Description = cs.Description;

                        await CharacterRepository.UpdateCustomSection(customSection);
                    }
                }

                // Si toujours pas de section, on la crée à partir du model
                if (customSection == null)
                {
                    customSection = modelCustomSection.ToSimpleModel(currentUserId);
                    customSection.CharacterId = characterId;

                    await CharacterRepository.CreateCustomSection(customSection);
                }

                // Propriétés
                await UpdateProperties(modelCustomSection.CustomProperties, customSection.CustomProperties, customSection.Id, currentUserId);

                sectionIds.Add(customSection.Id);
            }

            // On supprime les sections qu'on ne retrouve plus
            var sectionsToDelete = listCharacterSections?.Where(_ => !sectionIds.Contains(_.Id)).ToList();
            if (sectionsToDelete?.Any() == true)
            {
                await CharacterRepository.DeleteSectionsWithProperties(sectionsToDelete);
            }
        }

        private async Task UpdateProperties(IEnumerable<CustomPropertyDto> sectionDtos,
            IEnumerable<CustomProperty> characterSections, int characterSectionId, Guid currentUserId)
        {
            var listsectionDtos = sectionDtos?.ToList();
            var listCharacterSections = characterSections?.ToList();
            
            if (listsectionDtos?.Any() != true)
            {
                if (listCharacterSections?.Any() == true)
                {
                    await CharacterRepository.DeleteProperties(listCharacterSections);
                }

                return;
            }

            var propertyIds = new List<int>();

            foreach (var modelCustomProperty in listsectionDtos)
            {
                CustomProperty customProperty = null;

                // Si on a un Id, on essaye de récupérer la propriété dans la section
                if (modelCustomProperty.Id.HasValue)
                {
                    customProperty = listCharacterSections?.FirstOrDefault(_ => _.Id == modelCustomProperty.Id.Value);

                    if (customProperty != null)
                    {
                        var cp = modelCustomProperty.ToModel(currentUserId);

                        customProperty.Name = cp.Name;
                        customProperty.Description = cp.Description;
                        customProperty.TypeId = cp.TypeId;

                        await CharacterRepository.UpdateCustomProperty(customProperty);
                    }
                }

                // Si toujours pas de propriété, on la crée à partir du model
                if (customProperty == null)
                {
                    customProperty = modelCustomProperty.ToModel(currentUserId);
                    customProperty.CustomSectionId = characterSectionId;

                    await CharacterRepository.CreateCustomProperty(customProperty);
                }

                // Champs
                await UpdateFields(modelCustomProperty.CustomPropertyHasCustomFields, customProperty.CustomPropertyHasCustomFields, customProperty.Id, currentUserId);

                propertyIds.Add(customProperty.Id);
            }

            // Et on supprime celle qu'on n'a pas pu identifier
            var propertiesToDelete = listCharacterSections?.Where(_ => !propertyIds.Contains(_.Id)).ToList();
            if (propertiesToDelete?.Any() == true)
            {
                await CharacterRepository.DeleteAllCustomProperties(propertiesToDelete);
            }
        }

        private async Task UpdateFields(IEnumerable<CustomPropertyHasCustomFieldDto> propertieDtos,
            IEnumerable<CustomPropertyHasCustomField> characterProperties, int characterPropertyId, Guid currentUserId)
        {
            var listFieldDtos = propertieDtos?.ToList();
            var listCharacterFields = characterProperties?.ToList();
            
            if (listFieldDtos?.Any() != true)
            {
                if (listCharacterFields?.Any() == true)
                {
                    await CharacterRepository.DeleteFields(listCharacterFields);
                }

                return;
            }

            var fieldsIds = new List<int>();
            foreach (var modelCustomField in listFieldDtos)
            {
                CustomPropertyHasCustomField customField = null;

                // Si on a un Id, on essaye de récupérer le champ dans la propriété
                if (modelCustomField.Id.HasValue)
                {
                    customField = listCharacterFields?.FirstOrDefault(_ => _.Id == modelCustomField.Id.Value);

                    if (customField != null)
                    {
                        var cf = modelCustomField.ToModel(currentUserId);

                        customField.Valeur = cf.Valeur;

                        await CharacterRepository.UpdateCustomField(customField);
                    }
                }

                // Si toujours pas de propriété, on la crée à partir du model
                if (customField == null)
                {
                    customField = modelCustomField.ToModel(currentUserId);
                    customField.PropertyId = characterPropertyId;

                    await CharacterRepository.CreateCustomField(customField);
                }

                fieldsIds.Add(customField.Id);
            }

            // Et on supprime celle qu'on n'a pas pu identifier
            var fieldsToDelete = listCharacterFields?.Where(_ => !fieldsIds.Contains(_.Id)).ToList();
            if (fieldsToDelete?.Any() == true)
            {
                await CharacterRepository.DeleteAllCustomPropertiesHasCustomFields(fieldsToDelete);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRacesForSelect()
        {
            var races = await RaceRepository.GetAll();
            
            return Ok(races.Select(_ => new SelectListItem(_.Name, _.Id.ToString())));
        }

        [HttpPost]
        public async Task<IActionResult> AddNewRace(string name, string description)
        {
            var race = await RaceRepository.GetByName(name);

            if (race != null)
            {
                return Unauthorized();
            }
            
            race = await RaceRepository.Insert(new Race
            {
                Name = name,
                Description = description,
                Created = DateTime.Now,
                Modified = DateTime.Now,
                UserId = await CurrentUserAccessor.GetUserId()
            });

            if (race?.Name == name)
            {
                return Ok(race);
            }

            return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCharacterTypesForSelect()
        {
            var types = await CharacterTypeRepository.GetAll();
            
            return Ok(types.Select(_ => new SelectListItem(_.Name, _.Id.ToString())));
        }

        [HttpPost]
        public async Task<IActionResult> AddNewCharacterType(string name, string description)
        {
            var type = await CharacterTypeRepository.GetByName(name);

            if (type != null)
            {
                return Unauthorized();
            }
            
            type = await CharacterTypeRepository.Insert(new CharacterType
            {
                Name = name,
                Description = description,
                Created = DateTime.Now,
                Modified = DateTime.Now,
                UserId = await CurrentUserAccessor.GetUserId()
            });

            if (type?.Name == name)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomPropertyTypesForSelect()
        {
            var types = await CustomPropertyTypeRepository.GetAll();
            
            return Ok(types.Select(_ => new SelectListItem(_.Name, _.Id.ToString())));
        }

        [HttpGet]
        public async Task<IActionResult> LoadCustomFieldsForType(int id)
        {
            var type = await CustomPropertyTypeRepository.GetById(id);
            
            return Ok(type.Fields.Select(_ => new CustomFieldDto(_)));
        }

        [HttpPost]
        public async Task<IActionResult> AddNewCustomPropertyType(string name, string description)
        {
            var type = await CustomPropertyTypeRepository.GetByName(name);

            if (type != null)
            {
                return Unauthorized();
            }
            
            type = await CustomPropertyTypeRepository.Insert(new CustomPropertyType
            {
                Name = name,
                Description = description,
                Created = DateTime.Now,
                Modified = DateTime.Now,
                UserId = await CurrentUserAccessor.GetUserId()
            });

            if (type?.Name == name)
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}