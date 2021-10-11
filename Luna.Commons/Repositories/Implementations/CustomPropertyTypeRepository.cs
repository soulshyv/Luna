using System.Threading;
using System.Threading.Tasks;
using Luna.Commons.Models;
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
            return await DbContext.CustomPropertyTypes.SingleOrDefaultAsync(_ => _.Id == id, ctk);
        }

        public async Task<CustomPropertyType> GetByName(string name, CancellationToken ctk = default(CancellationToken))
        {
            return await DbContext.CustomPropertyTypes.SingleOrDefaultAsync(_ => _.Name == name, ctk);
        }
    }
}