using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Luna.Commons.Models;
using Luna.Commons.Models.Dtos;
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
                .Include(_ => _.CustomSections)
                    .ThenInclude(_ => _.CustomProperties)
                        .ThenInclude(_ => _.CustomPropertyHasCustomFields)
                            .ThenInclude(_ => _.CustomField)
                .SingleOrDefaultAsync(_ => _.Id == id, ctk);
        }

        // Sections
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

        // Propriétés
        public async Task<CustomProperty> CreateCustomProperty(CustomProperty property,
            CancellationToken ctk = default(CancellationToken))
        {
            await DbContext.AddAsync(property, ctk);
            
            await DbContext.SaveChangesAsync(ctk);

            return property;
        }

        public async Task<CustomProperty> UpdateCustomProperty(CustomProperty property,
            CancellationToken ctk = default(CancellationToken))
        {
            DbContext.Update(property);
            
            await DbContext.SaveChangesAsync(ctk);

            return property;
        }

        // Champs
        public async Task<CustomPropertyHasCustomField> CreateCustomField(CustomPropertyHasCustomField field,
            CancellationToken ctk = default(CancellationToken))
        {
            await DbContext.AddAsync(field, ctk);
            
            await DbContext.SaveChangesAsync(ctk);

            return field;
        }
        
        public async Task<CustomPropertyHasCustomField> UpdateCustomField(CustomPropertyHasCustomField field,
            CancellationToken ctk = default(CancellationToken))
        {
            DbContext.Update(field);
            
            await DbContext.SaveChangesAsync(ctk);

            return field;
        }

        // Suppressions
        public async Task<bool> DeleteFields(IEnumerable<CustomPropertyHasCustomField> fields,
            CancellationToken ctk = default(CancellationToken))
        {
            DbContext.RemoveRange(fields);

            var save = await DbContext.SaveChangesAsync(ctk);

            return save > 0;
        }

        public async Task<bool> DeleteProperties(IEnumerable<CustomProperty> properties,
            CancellationToken ctk = default(CancellationToken))
        {
            var customProperties = properties.ToList();
            
            foreach (var property in customProperties)
            {
                var res = await DeleteFields(property.CustomPropertyHasCustomFields, ctk);

                if (!res)
                {
                    return false;
                }
            }
            
            DbContext.RemoveRange(customProperties);

            var save = await DbContext.SaveChangesAsync(ctk);

            return save > 0;
        }

        public async Task<bool> DeleteSectionsWithProperties(IEnumerable<CustomSection> sections,
            CancellationToken ctk = default(CancellationToken))
        {
            var customSections = sections.ToList();
            
            foreach (var section in customSections)
            {
                var res = await DeleteProperties(section.CustomProperties, ctk);

                if (!res)
                {
                    return false;
                }
            }
            
            DbContext.RemoveRange(customSections);

            var save = await DbContext.SaveChangesAsync(ctk);

            return save > 0;
        }

        // Suppressions générales
        public async Task<bool> DeleteAllCustomProperties(IEnumerable<CustomProperty> properties,
            CancellationToken ctk = default(CancellationToken))
        {
            DbContext.RemoveRange(properties);

            var res = await DbContext.SaveChangesAsync(ctk);

            return res > 0;
        }

        public async Task<bool> DeleteAllCustomPropertiesHasCustomFields(IEnumerable<CustomPropertyHasCustomField> properties,
            CancellationToken ctk = default(CancellationToken))
        {
            DbContext.RemoveRange(properties);

            var res = await DbContext.SaveChangesAsync(ctk);

            return res > 0;
        }
    }
}