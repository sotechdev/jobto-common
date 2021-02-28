using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobTo.Common.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<int> Insert(T model);
        Task<int> Update(T model);
        Task<int> Delete(T model);
        Task<T> Get(long grid);
        Task<T> Get(int code);
        Task<IList<T>> All();
    }
}
