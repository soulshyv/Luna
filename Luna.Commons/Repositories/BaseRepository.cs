using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Luna.Commons.Repositories
{
    public abstract class BaseRepository<TModel, TDbContext>
        where TModel : class, new()
        where TDbContext : DbContext
    {
        protected TDbContext DbContext { get; set; }
        protected Func<TDbContext, DbSet<TModel>> TableSet { get; set; }
        
        protected BaseRepository(TDbContext dbContext, Func<TDbContext, DbSet<TModel>> tableDbSet)
        {
            DbContext = dbContext;
            TableSet = tableDbSet;
        }

        public abstract Task<TModel> GetById(int id, CancellationToken ctk = default(CancellationToken));

        public async Task<TModel[]> GetAll(CancellationToken ctk = default(CancellationToken))
        {
            return await TableSet(DbContext).ToArrayAsync(cancellationToken: ctk);
        }

        public virtual async Task<TModel> Insert(TModel item, CancellationToken ctk = default(CancellationToken))
        {
            await TableSet(DbContext).AddAsync(item, ctk);

            await DbContext.SaveChangesAsync(ctk);

            return item;
        }

        public virtual async Task<TModel> Update(TModel item, CancellationToken ctk = default(CancellationToken))
        {
            TableSet(DbContext).Update(item);

            await DbContext.SaveChangesAsync(ctk);

            return item;
        }

        public virtual async Task<bool> Delete(TModel item, CancellationToken ctk = default(CancellationToken))
        {
            TableSet(DbContext).Remove(item);

            var res = await DbContext.SaveChangesAsync(ctk);

            return res > 0;
        }

        public virtual async Task<bool> DeleteById(int id, CancellationToken ctk = default(CancellationToken))
        {
            var item = await GetById(id, ctk);

            TableSet(DbContext).Remove(item);

            var res = await DbContext.SaveChangesAsync(ctk);
            return res > 0;
        }
    }
}