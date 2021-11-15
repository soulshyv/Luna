using System;
using System.Collections.Generic;
using System.Linq;

namespace Luna.Commons.Models.Dtos
{
    public class CustomSectionDto : ModelBaseDto<CustomSection>
    {
        public int Order { get; set; }
        
        public IEnumerable<CustomPropertyDto> CustomProperties { get; set; }

        public CustomSectionDto(CustomSection section) : base(section)
        {
            Order = section.Order;
            CustomProperties = section.CustomProperties?.Any() == true
                ? section.CustomProperties.Select(_ => new CustomPropertyDto(_))
                : null;
        }

        public CustomSectionDto()
        {
        }

        public override CustomSection ToModel(Guid userId)
        {
            var customSection = base.ToModel(userId);

            customSection.CustomProperties = CustomProperties.Select(_ => _.ToModel(userId)).ToList();
            
            return customSection;
        }

        public CustomSection ToSimpleModel(Guid userId)
        {
            var customSection = base.ToModel(userId);

            customSection.Order = Order;
            
            return customSection;
        }
    }
}