using System.Collections.Generic;
using System.Linq;
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

        public async Task<CustomField> CreateCustomField(CustomField field,
            CancellationToken ctk = default(CancellationToken))
        {
            await DbContext.CustomFields.AddAsync(field, ctk);
            
            await DbContext.SaveChangesAsync(ctk);

            return field;
        }

        public async Task<CustomField> UpdateCustomField(CustomField field,
            CancellationToken ctk = default(CancellationToken))
        {
            DbContext.CustomFields.Update(field);
            
            await DbContext.SaveChangesAsync(ctk);

            return field;
        }

        public override async Task<bool> DeleteById(int id, CancellationToken ctk = default(CancellationToken))
        {
            var type = await DbContext.CustomPropertyTypes
                .Include(_ => _.Fields).ThenInclude(_ => _.CustomPropertyHasCustomFields)
                .SingleOrDefaultAsync(_ => _.Id == id, ctk);
            
            await DeleteCustomFields(type.Fields, ctk);
            DbContext.Remove(type);

            var res = await DbContext.SaveChangesAsync(ctk);
            
            return res > 0;
        }

        public async Task<IEnumerable<CustomPropertyHasCustomField>> GetAllCustomPropertyHasCustomFieldByTypeId(int typeId, CancellationToken ctk = default(CancellationToken))
        {
            return await DbContext.CustomPropertyHasCustomFields
                .Include(_ => _.CustomField)
                .Where(_ => _.CustomField.TypeId == typeId)
                .ToArrayAsync(ctk);
        }

        public async Task<IEnumerable<CustomPropertyHasCustomField>> CreateCustomPropertyHasCustomField(
            IEnumerable<CustomPropertyHasCustomField> customPropertyHasCustomField,
            CancellationToken ctk = default(CancellationToken))
        {
            var customFields = customPropertyHasCustomField.ToList();
            
            foreach (var customField in customFields)
            {
                await DbContext.CustomPropertyHasCustomFields.AddAsync(customField, ctk);
            }
            
            await DbContext.SaveChangesAsync(ctk);

            return customFields;
        }

        public async Task<bool> DeleteCustomFields(IEnumerable<CustomField> fields,
            CancellationToken ctk = default(CancellationToken))
        {
            var customFields = fields.ToList();
            foreach (var field in customFields.Where(_ => _.CustomPropertyHasCustomFields?.Any() == true))
            {
                DbContext.CustomPropertyHasCustomFields.RemoveRange(field.CustomPropertyHasCustomFields);
            }
            
            DbContext.CustomFields.RemoveRange(customFields);
            
            var res = await DbContext.SaveChangesAsync(ctk);

            return res > 0;
        }
    }
}