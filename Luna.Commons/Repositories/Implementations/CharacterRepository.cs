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
    }
}