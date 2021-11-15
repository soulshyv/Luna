using System;
using System.Collections.Generic;
using System.Linq;

namespace Luna.Commons.Models.Dtos
{
    public class CustomPropertyDto : ModelBaseDto<CustomProperty>
    {
        public int Order { get; set; }
        
        public CustomPropertyTypeDto Type { get; set; }
        public IEnumerable<CustomPropertyHasCustomFieldDto> CustomPropertyHasCustomFields { get; set; }

        public CustomPropertyDto(CustomProperty property) : base(property)
        {
            Order = property.Order;
            Type = property.Type != null ? new CustomPropertyTypeDto(property.Type) : null;
            CustomPropertyHasCustomFields = property.CustomPropertyHasCustomFields?.Any() == true
                ? property.CustomPropertyHasCustomFields.Select(_ => new CustomPropertyHasCustomFieldDto(_)).ToList()
                : null;
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

            customProperty.Order = Order;

            return customProperty;
        }
    }
}