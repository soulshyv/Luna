namespace Luna.Commons.Models.Dtos
{
    public class CharacterTypeDto : ModelBaseDto<CharacterType>
    {
        public CharacterTypeDto()
        {
        }

        public CharacterTypeDto(CharacterType type) : base(type)
        {
        }
    }
}