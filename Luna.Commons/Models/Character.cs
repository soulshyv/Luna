using System.Collections.Generic;

namespace Luna.Commons.Models
{
    public class Character : ModelBase
    {
        public virtual int TypeId { get; set; }
        public virtual int RaceId { get; set; }
        
        public virtual CharacterType Type { get; set; }
        public virtual Race Race { get; set; }
        public virtual IList<CustomSection> CustomSections { get; set; }
    }
}