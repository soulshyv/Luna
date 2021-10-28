using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Luna.Commons.Models;
using Microsoft.EntityFrameworkCore;

namespace Luna.Commons.Repositories.Implementations
{
    public class CharacterRepository : BaseRepository<Character, LunaDbContext>
    {
        public CharacterRepository(LunaDbContext dbContext) : base(dbContext, _ => _.Characters)
        {
        }
        
        public override async Task<Character> GetById(int id, CancellationToken ctk = default(CancellationToken))
        {
            return await DbContext.Characters.SingleOrDefaultAsync(_ => _.Id == id, ctk);
        }

        public override async Task<Character[]> GetAll(CancellationToken ctk = default(CancellationToken))
        {
            return await DbContext.Characters
                .Include(_ => _.Type)
                .Include(_ => _.Race)
                .ToArrayAsync(ctk);
        }

        public async Task<Character> GetFullCharacterById(int id, CancellationToken ctk = default(CancellationToken))
        {
            return await DbContext.Characters
                .Include(_ => _.Type)
                .Include(_ => _.Race)
                    .ThenInclude(_ => _.CustomProperties)
                        .ThenInclude(_ => _.Type)
                .Include(_ => _.CustomSections)
                    .ThenInclude(_ => _.CustomProperties)
                        .ThenInclude(_ => _.Type)
                .SingleOrDefaultAsync(_ => _.Id == id, ctk);
        }

        public async Task<CustomSection> CreateCustomSection(CustomSection section,
            CancellationToken ctk = default(CancellationToken))
        {
            await DbContext.AddAsync(section, ctk);
            
            await DbContext.SaveChangesAsync(ctk);

            return section;
        }

        public async Task<CustomSection> UpdateCustomSection(CustomSection section,
            CancellationToken ctk = default(CancellationToken))
        {
            DbContext.Update(section);
            
            await DbContext.SaveChangesAsync(ctk);

            return section;
        }

        public async Task<IEnumerable<CustomProperty>> CreateCustomProperties(IEnumerable<CustomProperty> properties,
            CancellationToken ctk = default(CancellationToken))
        {
            var customProperties = properties.ToList();
            
            await DbContext.AddRangeAsync(customProperties, ctk);
            
            await DbContext.SaveChangesAsync(ctk);

            return customProperties;
        }

        public async Task<CustomProperty> UpdateCustomProperty(CustomProperty property,
            CancellationToken ctk = default(CancellationToken))
        {
            DbContext.Update(property);
            
            await DbContext.SaveChangesAsync(ctk);

            return property;
        }

        public async Task<bool> DeleteSectionWithProperties(CustomSection section,
            CancellationToken ctk = default(CancellationToken))
        {
            var properties = section.CustomProperties;

            DbContext.RemoveRange(properties);
            DbContext.Remove(section);

            var res = await DbContext.SaveChangesAsync(ctk);

            return res > 0;
        }

        public async Task<bool> DeleteSectionsWithProperties(IEnumerable<CustomSection> sections,
            CancellationToken ctk = default(CancellationToken))
        {
            foreach (var section in sections)
            {
                var res = await DeleteSectionWithProperties(section, ctk);

                if (!res)
                {
                    return false;
                }
            }

            return true;
        }

        public async Task<bool> DeleteAllCustomProperties(IEnumerable<CustomProperty> properties,
            CancellationToken ctk = default(CancellationToken))
        {
            DbContext.RemoveRange(properties);

            var res = await DbContext.SaveChangesAsync(ctk);

            return res > 0;
        }
    }
}