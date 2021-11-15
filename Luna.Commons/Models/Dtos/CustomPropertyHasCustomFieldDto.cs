using System;
using System.Collections.Generic;

namespace Luna.Commons.Models.Dtos
{
    public class CustomPropertyHasCustomFieldDto
    {
        public int? Id { get; set; }
        public string Valeur { get; set; }
        
        public CustomFieldDto Field { get; set; }

        public CustomPropertyHasCustomFieldDto(CustomPropertyHasCustomField customPropertyHasCustomField)
        {
            Id = customPropertyHasCustomField.Id;
            Valeur = customPropertyHasCustomField.Valeur;
            Field = customPropertyHasCustomField.CustomField != null ? new CustomFieldDto(customPropertyHasCustomField.CustomField) : null;
        }

        public CustomPropertyHasCustomFieldDto()
        {
        }

        public CustomPropertyHasCustomField ToModel(Guid userId)
        {
            var customPropertyHasCustomField = ToSimpleModel(userId);

            if (Field?.Id != null)
            {
                customPropertyHasCustomField.FieldId = Field.ToModel(userId).Id;
            }
            
            return customPropertyHasCustomField;
        }

        public CustomPropertyHasCustomField ToSimpleModel(Guid userId)
        {
            var customPropertyHasCustomField = new CustomPropertyHasCustomField()
            {
                Valeur = Valeur,
                UserId = userId,
                Modified = DateTime.Now
            };

            if (Id.HasValue)
            {
                customPropertyHasCustomField.Id = Id.Value;
            }
            else
            {
                customPropertyHasCustomField.Created = DateTime.Now;
            }
            
            return customPropertyHasCustomField;
        }
    }
}