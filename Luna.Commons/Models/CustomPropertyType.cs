using System.Collections.Generic;

namespace Luna.Commons.Models
{
    public class CustomPropertyType : ModelBase
    {
        public virtual IList<CustomProperty> CustomProperties { get; set; }
        public virtual IList<CustomField> Fields { get; set; }
    }
}