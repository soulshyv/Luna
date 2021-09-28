using System.Collections.Generic;

namespace Luna.Commons.Models
{
    public class CustomSection : ModelBase
    {
        public virtual int CharacterId { get; set; }
        
        public virtual Character Character { get; set; }
        public virtual IList<CustomProperty> CustomProperties { get; set; }
    }
}