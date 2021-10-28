using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Luna.Commons.Models;
using Luna.Commons.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Luna.Commons.Repositories.Implementations
{
    public class CustomPropertyTypeRepository : BaseRepository<CustomPropertyType, LunaDbContext>
    {
        public CustomPropertyTypeRepository(LunaDbContext dbContext) : base(dbContext, _ => _.CustomPropertyTypes)
        {
        }
        
        public override async Task<CustomPropertyType> GetById(int id, CancellationToken ctk = default(CancellationToken))
        {
            return await DbContext.CustomPropertyTypes
                .Include(_ => _.Fields)
                .SingleOrDefaultAsync(_ => _.Id == id, ctk);
        }

        public async Task<CustomPropertyType> GetByName(string name, CancellationToken ctk = default(CancellationToken))
        {
            return await DbContext.CustomPropertyTypes
                .Include(_ => _.Fields)
                .SingleOrDefaultAsync(_ => _.Name == name, ctk);
        }

        public async Task<CustomField> CreateCustomFields(CustomField field,
            CancellationToken ctk = default(CancellationToken))
        {
            await DbContext.CustomFields.AddAsync(field, ctk);
            
            await DbContext.SaveChangesAsync(ctk);

            return field;
        }

        public override async Task<bool> DeleteById(int id, CancellationToken ctk = default(CancellationToken))
        {
            var type = await GetById(id, ctk);
            await DeleteCustomFields(type.Fields, ctk);
            DbContext.Remove(type);

            var res = await DbContext.SaveChangesAsync(ctk);
            
            return res > 0;
        }

        public async Task<bool> DeleteCustomFields(IEnumerable<CustomField> fields,
            CancellationToken ctk = default(CancellationToken))
        {
            DbContext.CustomFields.RemoveRange(fields);
            
            var res = await DbContext.SaveChangesAsync(ctk);

            return res > 0;
        }
    }
}