using JobTo.Commom.Models;
using System.Threading.Tasks;

namespace JobTo.Common.Repositories
{
    public interface IClientRepository : IRepository<Person>
    {
        Task<Person> GetByDoc(string doc);
    }
}
