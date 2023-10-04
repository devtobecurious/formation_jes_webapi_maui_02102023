using SuiviDesWookiees.Libs;

namespace SuiviDesWookiees.UI.Mobile.Services
{
    public interface IGetWookieesService
    {
        Task<IEnumerable<Wookiee>> GetWookiees();
    }

    public class HttpGetWookieesService : IGetWookieesService
    {
        public Task<IEnumerable<Wookiee>> GetWookiees()
        {
            throw new NotImplementedException();
        }
    }
}
