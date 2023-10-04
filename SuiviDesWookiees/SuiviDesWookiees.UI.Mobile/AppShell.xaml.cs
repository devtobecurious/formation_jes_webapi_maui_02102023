namespace SuiviDesWookiees.UI.Mobile
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(AddWookiee), typeof(AddWookiee));
        }
    }
}