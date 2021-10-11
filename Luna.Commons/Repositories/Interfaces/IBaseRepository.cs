using System.Threading;
using System.Threading.Tasks;
using Luna.Commons.Models;

namespace Luna.Commons.Repositories.Interfaces
{
    public interface IBaseRepository<TModel> where TModel : ModelBase
    {
        Task<TModel> GetById(int id, CancellationToken ctk = default(CancellationToken));
        Task<TModel[]> GetAll(CancellationToken ctk = default(CancellationToken));
        Task<TModel> Insert(TModel item, CancellationToken ctk = default(CancellationToken));
        Task<TModel> Update(TModel item, CancellationToken ctk = default(CancellationToken));
        Task<bool> Delete(TModel item, CancellationToken ctk = default(CancellationToken));
        Task<bool> DeleteById(int id, CancellationToken ctk = default(CancellationToken));
    }
}