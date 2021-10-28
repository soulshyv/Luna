using System;

namespace Luna.Commons.Models.Dtos
{
    public class CustomPropertyDto : ModelBaseDto<CustomProperty>
    {
        public int Valeur { get; set; }
        public int? ValeurMax { get; set; }
        public string Unite { get; set; }
        
        public CustomPropertyTypeDto Type { get; set; }

        public CustomPropertyDto(CustomProperty property) : base(property)
        {
            Type = property.Type != null ? new CustomPropertyTypeDto(property.Type) : null;
        }

        public CustomPropertyDto()
        {
        }

        public override CustomProperty ToModel(Guid userId)
        {
            var customProperty = ToSimpleModel(userId);

            if (Type?.Id != null)
            {
                customProperty.TypeId = Type.ToModel(userId).Id;
            }
            
            return customProperty;
        }

        public CustomProperty ToSimpleModel(Guid userId)
        {
            var customProperty = base.ToModel(userId);

            return customProperty;
        }
    }
}