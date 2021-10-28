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

            if (model.CustomSections?.Any() == true)
            {
                var sectionIds = new List<int>();
                foreach (var modelCustomSection in model.CustomSections)
                {
                    CustomSection customSection = null;
                    
                    // Si on a un Id, on essaye de récupérer la section dans le perso
                    if (modelCustomSection.Id.HasValue)
                    {
                        customSection =
                            character.CustomSections.FirstOrDefault(_ => _.Id == modelCustomSection.Id.Value);

                        if (customSection != null)
                        {
                            customSection.Name = modelCustomSection.Name;
                            customSection.Description = modelCustomSection.Description;

                            await CharacterRepository.UpdateCustomSection(customSection);
                        }
                    }

                    // Si toujours pas de section, on la crée à partir du model
                    if (customSection == null)
                    {
                        customSection = modelCustomSection.ToSimpleModel(currentUserId);
                        customSection.CharacterId = character.Id;
                        
                        await CharacterRepository.CreateCustomSection(customSection);
                    }

                    var propertyIds = new List<int>();
                    
                    // Nouvelles propriétés
                    var newCustomProperties = modelCustomSection.CustomProperties
                        .Where(_ => !_.Id.HasValue)
                        .Select(_ =>
                        {
                            var cp = _.ToModel(currentUserId);
                            cp.CustomSectionId = customSection.Id;
                            return cp;
                        })
                        .ToList();
                    if (newCustomProperties.Any())
                    {
                        await CharacterRepository.CreateCustomProperties(newCustomProperties);
                    }
                    
                    propertyIds.AddRange(newCustomProperties.Select(_ => _.Id));

                    // Si on a déjà des propriétés dans la section
                    if (customSection.CustomProperties?.Any() == true)
                    {
                        // On met à jour celle qu'on a reçu depuis le formulaire
                        foreach (var sectionCustomProperty in customSection.CustomProperties)
                        {
                            var modelCustomProperty =
                                modelCustomSection.CustomProperties.FirstOrDefault(
                                    _ => _.Id == sectionCustomProperty.Id);
                            if (modelCustomProperty == null)
                            {
                                continue;
                            }

                            sectionCustomProperty.Name = modelCustomProperty.Name;
                            sectionCustomProperty.Description = modelCustomProperty.Description;
                            // sectionCustomProperty.Valeur = modelCustomProperty.Valeur;
                            // sectionCustomProperty.ValeurMax = modelCustomProperty.ValeurMax;
                            // sectionCustomProperty.Unite = modelCustomProperty.Unite;

                            await CharacterRepository.UpdateCustomProperty(sectionCustomProperty);

                            propertyIds.Add(sectionCustomProperty.Id);
                        }

                        // Et on supprime celle qu'on n'a pas pu identifier
                        var propertiesToDelete = customSection.CustomProperties.Where(_ => !propertyIds.Contains(_.Id));
                        await CharacterRepository.DeleteAllCustomProperties(propertiesToDelete);
                    }

                    sectionIds.Add(customSection.Id);
                }
                
                // On supprime les sections qu'on ne retrouve plus
                var sectionsToDelete = character.CustomSections.Where(_ => !sectionIds.Contains(_.Id));
                await CharacterRepository.DeleteSectionsWithProperties(sectionsToDelete);
            }
            else
            {
                await CharacterRepository.DeleteSectionsWithProperties(character.CustomSections);
            }
            
            return Ok(Url.Action("Index", "Character"));
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