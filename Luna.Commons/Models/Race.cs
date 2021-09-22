using System.Collections.Generic;

namespace Luna.Commons.Models
{
    public class Race : ModelBase
    {
        public virtual IList<CustomProperty> CustomProperties { get; set; }
        public virtual IList<Character> Characters { get; set; }
    }
}