using System;
using System.Collections.Generic;
using System.Linq;

namespace Luna.Commons.Models.Dtos
{
    public class RaceDto : ModelBaseDto<Race>
    {
        public IEnumerable<CustomPropertyDto> CustomProperties { get; set; }

        public RaceDto(Race race)
        {
            Id = race.Id;
            Name = race.Name;
            Description = race.Description;
            
            CustomProperties = race.CustomProperties?.Any() == true
                ? race.CustomProperties.Select(_ => new CustomPropertyDto(_))
                : null;
        }

        public RaceDto()
        {
        }

        public override Race ToModel(Guid userId)
        {
            var race = base.ToModel(userId);
            
            race.CustomProperties = CustomProperties?.Select(_ => _.ToModel(userId)).ToList();
            
            return race;
        }
    }
}