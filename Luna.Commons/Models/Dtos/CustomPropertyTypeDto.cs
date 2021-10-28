using System;
using System.Collections.Generic;
using System.Linq;

namespace Luna.Commons.Models.Dtos
{
    public class CustomPropertyTypeDto : ModelBaseDto<CustomPropertyType>
    {
        public IEnumerable<CustomFieldDto> Fields { get; set; }
        
        public CustomPropertyTypeDto(CustomPropertyType type) : base(type)
        {
            Fields = type.Fields?.Any() == true
                ? type.Fields.Select(_ => new CustomFieldDto(_))
                : null;
        }

        public CustomPropertyTypeDto()
        {
        }

        public CustomPropertyType ToSimpleModel(Guid userId)
        {
            return base.ToModel(userId);
        }

        public override CustomPropertyType ToModel(Guid userId)
        {
            var customPropertyType = base.ToModel(userId);

            customPropertyType.Fields = Fields?.Select(_ => _.ToModel(userId)).ToList();
            
            return customPropertyType;
        }
    }
}