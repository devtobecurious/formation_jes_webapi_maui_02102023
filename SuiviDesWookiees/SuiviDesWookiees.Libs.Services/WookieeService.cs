using Microsoft.Extensions.Configuration;

namespace SuiviDesWookiees.Libs.Services
{
    public class WookieeService : IWookieeService
    {
        private readonly IConfiguration config;

        public WookieeService(IStringToUpperService service,
            IConfiguration config)
        {
            Service = service;
            this.config = config;

            // var chaineConnection = this.config["ConnectionStrings:MaClefVers"];
            var chaineConnection = this.config.GetConnectionString("MaClefVers");
        }

        public IStringToUpperService Service { get; }

        public IEnumerable<Wookiee> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}