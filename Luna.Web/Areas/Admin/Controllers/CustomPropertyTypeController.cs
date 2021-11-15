using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Luna.Commons.Models;
using Luna.Commons.Models.Dtos;
using Luna.Commons.Repositories.Implementations;
using Luna.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Luna.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CustomPropertyTypeController : EntityController<CustomPropertyType>
    {
        protected override string _entityName => "Type de propriété personnalisée";

        public CustomPropertyTypeController(ILifetimeScope scope) : base(scope)
        {
        }

        [HttpGet]
        public async override Task<IActionResult> Add()
        {
            ViewBag.Title = _entityName;
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CustomPropertyTypeDto model)
        {
            var userId = await CurrentUserAccessor.GetUserId();
            
            var type = model.ToModel(userId);

            await ((CustomPropertyTypeRepository) Repo).Insert(type);
            
            return Ok(Url.Action("Edit", "CustomPropertyType", new { id = type.Id }));
        }

        [HttpGet]
        public override async Task<IActionResult> Edit(int id)
        {
            ViewBag.Title = _entityName;

            return View(id);
        }

        [HttpGet]
        public async Task<IActionResult> GetTypeById(int id)
        {
            var type = await ((CustomPropertyTypeRepository) Repo).GetById(id);

            if (type == null)
            {
                return NotFound();
            }
            
            return Ok(new CustomPropertyTypeDto(type));
        }

        [HttpPost]
        public async Task<IActionResult> Update(CustomPropertyTypeDto model)
        {
            var userId = await CurrentUserAccessor.GetUserId();

            if (!model.Id.HasValue)
            {
                return RedirectToAction("Index");
            }

            var customPropertyTypeRepository = (CustomPropertyTypeRepository) Repo;
            
            var type = await customPropertyTypeRepository.GetById(model.Id.Value);
            type.Name = model.Name;
            type.Description = model.Description;

            var fieldIds = new List<int>();
            foreach (var customFieldDto in model.Fields)
            {
                
                CustomField customField = null;
                    
                // Si on a un Id, on essaye de récupérer le champ dans le type
                if (customFieldDto.Id.HasValue)
                {
                    customField =
                        type.Fields.FirstOrDefault(_ => _.Id == customFieldDto.Id.Value);

                    if (customField != null)
                    {
                        customField.Name = customFieldDto.Name;
                        customField.Description = customFieldDto.Description;

                        await customPropertyTypeRepository.UpdateCustomField(customField);
                    }
                }

                // Si toujours pas de champ, on le crée à partir du model
                if (customField == null)
                {
                    customField = customFieldDto.ToModel(userId);
                    customField.TypeId = type.Id;
                        
                    await customPropertyTypeRepository.CreateCustomField(customField);

                    var customPropertyHasCustomFields = await customPropertyTypeRepository.GetAllCustomPropertyHasCustomFieldByTypeId(type.Id);
                    var customPropertyIds = customPropertyHasCustomFields.Select(_ => _.PropertyId).Distinct();
                    var newCustomPropertyHasCustomFields = customPropertyIds.Select(_ => new CustomPropertyHasCustomField
                    {
                        FieldId = customField.Id,
                        PropertyId = _,
                        Created = DateTime.Now,
                        Modified = DateTime.Now,
                        UserId = userId
                    });
                    await customPropertyTypeRepository.CreateCustomPropertyHasCustomField(
                        newCustomPropertyHasCustomFields
                    );
                }
                
                fieldIds.Add(customField.Id);
            }
            
            var fieldsToDelete = type.Fields.Where(_ => !fieldIds.Contains(_.Id));
            await customPropertyTypeRepository.DeleteCustomFields(fieldsToDelete);

            return Ok(Url.Action("Index", "CustomPropertyType"));
        }

        [HttpGet]
        public override async Task<IActionResult> Delete(int id)
        {
            await ((CustomPropertyTypeRepository) Repo).DeleteById(id);
            
            return RedirectToAction("Index");
        }
    }
}