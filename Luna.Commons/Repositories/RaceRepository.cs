using System;
using System.Threading;
using System.Threading.Tasks;
using Luna.Commons.Models;
using Microsoft.EntityFrameworkCore;

namespace Luna.Commons.Repositories
{
    public class RaceRepository : BaseRepository<Race, LunaDbContext>
    {
        public RaceRepository(LunaDbContext dbContext) : base(dbContext, _ => _.Races)
        {
        }
        
        public override async Task<Race> GetById(int id, CancellationToken ctk = default(CancellationToken))
        {
            return await DbContext.Races.SingleOrDefaultAsync(_ => _.Id == id, ctk);
        }

        public async Task<Race> GetByName(string name, CancellationToken ctk = default(CancellationToken))
        {
            return await DbContext.Races.SingleOrDefaultAsync(_ => _.Name == name, ctk);
        }
    }
}