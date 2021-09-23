using System.Collections.Generic;
using Luna.Commons.Models;

namespace Luna.ViewModels
{
    public class CharacterViewModel
    {
        public Character Character { get; set; }
        public IEnumerable<Race> Races { get; set; }
        public IEnumerable<CharacterType> Types { get; set; }
    }
}