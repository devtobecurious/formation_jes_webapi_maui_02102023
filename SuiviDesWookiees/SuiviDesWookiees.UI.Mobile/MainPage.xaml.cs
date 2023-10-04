using SuiviDesWookiees.UI.Mobile.ViewModels;

namespace SuiviDesWookiees.UI.Mobile
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();

            this.viewModel = new WookieeListViewModel();
            this.BindingContext = viewModel;

            // Shell.Current.GoToAsync()
        }

        private WookieeListViewModel viewModel;

        private void OnCounterClicked(object sender, EventArgs e)
        {
            //count++;

            //if (count == 1)
            //    CounterBtn.Text = $"Clicked {count} time";
            //else
            //    CounterBtn.Text = $"Clicked {count} times";

            //SemanticScreenReader.Announce(CounterBtn.Text);
        }

        private void btnGoToAdd_Clicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync($"{nameof(AddWookiee)}?defaultPower=10");
        }
    }
}