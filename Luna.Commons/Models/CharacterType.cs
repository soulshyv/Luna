using System.Collections.Generic;

namespace Luna.Commons.Models
{
    public class CharacterType : ModelBase
    {
        public virtual IList<Character> Characters { get; set; }
    }
}