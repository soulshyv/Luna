using System.Collections.Generic;

namespace Luna.Commons.Models.Dtos
{
    public class CharacterDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public CharacterType Type { get; set; }
        public Race Race { get; set; }
        public IEnumerable<CustomProperty> CustomProperties { get; set; }

        public CharacterDto(Character character)
        {
            Id = character.Id;
            Name = character.Name;
            Description = character.Description;
            Type = character.Type;
            Race = character.Race;
            CustomProperties = character.CustomProperties;
        }

        public CharacterDto()
        {
        }
    }
}