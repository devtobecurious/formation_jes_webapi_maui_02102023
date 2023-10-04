using Microsoft.Extensions.Configuration;

namespace SuiviDesWookiees.UI.Mobile
{
    public partial class App : Application
    {
        public App(IConfiguration configuration)
        {
            InitializeComponent();

            MainPage = new AppShell();
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
    }
}