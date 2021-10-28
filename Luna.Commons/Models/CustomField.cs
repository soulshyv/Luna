using System.Collections.Generic;

namespace Luna.Commons.Models
{
    public class CustomField : ModelBase
    {
        public virtual int TypeId { get; set; }
        
        public virtual CustomPropertyType Type { get; set; }
        
        public virtual IList<CustomPropertyHasCustomField> CustomPropertyHasCustomFields { get; set; }
    }
}