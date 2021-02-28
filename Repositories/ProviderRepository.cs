using JobTo.Commom.Data;
using JobTo.Commom.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobTo.Common.Repositories
{
    public class ProviderRepository : IProviderRepository
    {
        private readonly JobToDbContext _context;
        public ProviderRepository(JobToDbContext context)
        {
            _context = context;
        }
        public async Task<IList<Person>> All()
        {
            return await _context.People
                .Where(p => p.Flag == 'A')
                .Where(p => p.PersonType.Contains("P"))
                .ToListAsync();
        }

        public async Task<int> Delete(Person model)
        {
            model.Flag = 'D';
            _context.People.Update(model);
            return await _context.SaveChangesAsync();
        }

        public async Task<Person> Get(long grid)
        {
            return await _context.People
                .Where(x => x.Grid == grid)
                .FirstOrDefaultAsync();
        }

        public async Task<Person> Get(int code)
        {
            return await _context.People
                .Where(x => x.Code == code)
                .FirstOrDefaultAsync();
        }

        public async Task<int> Insert(Person model)
        {
            _context.People.Add(model);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Update(Person model)
        {
            _context.People.Update(model);
            return await _context.SaveChangesAsync();
        }
    }
}
