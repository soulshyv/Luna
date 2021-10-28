using System;
using System.Collections.Generic;
using System.Linq;

namespace Luna.Commons.Models.Dtos
{
    public class CharacterDto : ModelBaseDto<Character>
    {
        public CharacterTypeDto Type { get; set; }
        public RaceDto Race { get; set; }
        
        public IEnumerable<CustomSectionDto> CustomSections { get; set; }

        public CharacterDto(Character character) : base(character)
        {
            Type = character.Type != null ? new CharacterTypeDto(character.Type) : null;
            Race = character.Race != null ? new RaceDto(character.Race) : null;
            
            CustomSections = character.CustomSections?.Any() == true
                ? character.CustomSections.Select(_ => new CustomSectionDto(_))
                : null;
        }

        public CharacterDto()
        {
        }

        public Character ToSimpleModel(Guid userId)
        {
            return base.ToModel(userId);
        }

        public override Character ToModel(Guid userId)
        {
            var character = base.ToModel(userId);

            character.Type = Type.ToModel(userId);
            character.Race = Race.ToModel(userId);
            character.CustomSections = CustomSections?.Select(_ => _.ToModel(userId)).ToList();

            return character;
        }
    }
}