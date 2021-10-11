using System.Threading;
using System.Threading.Tasks;
using Luna.Commons.Models;
using Microsoft.EntityFrameworkCore;

namespace Luna.Commons.Repositories.Implementations
{
    public class CharacterTypeRepository : BaseRepository<CharacterType, LunaDbContext>
    {
        public CharacterTypeRepository(LunaDbContext dbContext) : base(dbContext, _ => _.CharacterTypes)
        {
        }
        
        public override async Task<CharacterType> GetById(int id, CancellationToken ctk = default(CancellationToken))
        {
            return await DbContext.CharacterTypes.SingleOrDefaultAsync(_ => _.Id == id, ctk);
        }

        public async Task<CharacterType> GetByName(string name, CancellationToken ctk = default(CancellationToken))
        {
            return await DbContext.CharacterTypes.SingleOrDefaultAsync(_ => _.Name == name, ctk);
        }
    }
}