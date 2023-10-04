using Microsoft.Extensions.Options;

namespace SuiviDesWookiees.Libs.Services
{
    public class InMemoryWookieeService : IWookieeService
    {
        public InMemoryWookieeService(IOptions<GameSetting> options)
        {
            this.GameSetting = options.Value;
        }

        public IEnumerable<Wookiee> GetAll()
        {
            List<Wookiee> wookiees = new();

            for (int i = 0; i < this.GameSetting.NbWookiees; i++)
            {
                wookiees.Add(new(i, new(this.GameSetting.Position.X, this.GameSetting.Position.Y)));
            }

            return wookiees;
        }

        public GameSetting GameSetting { get; init; }
    }
}
