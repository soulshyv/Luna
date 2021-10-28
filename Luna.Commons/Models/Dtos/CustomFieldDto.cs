using System;
using System.Collections.Generic;
using System.Linq;

namespace Luna.Commons.Models.Dtos
{
    public class CustomFieldDto : ModelBaseDto<CustomField>
    {
        public CustomFieldDto(CustomField field) : base(field)
        {
        }

        public CustomFieldDto()
        {
        }
    }
}