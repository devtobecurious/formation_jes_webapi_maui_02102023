using Microsoft.EntityFrameworkCore;
using SuiviDesWookiees.Libs.Services.Data;

namespace SuiviDesWookiees.Libs.Services
{
    public class OracleDatabaseWookieeService : IWookieeService
    {
        private readonly WookieeDbContext context;

        public OracleDatabaseWookieeService(WookieeDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Wookiee> GetAll()
        {
            return this.context.Wookiees.AsNoTracking().Where(item => item.Surname == "Hello").ToList();
        }

        public Wookiee GetOne()
        {
            return new Wookiee(1, new(1, 3));
        }
    }
}
