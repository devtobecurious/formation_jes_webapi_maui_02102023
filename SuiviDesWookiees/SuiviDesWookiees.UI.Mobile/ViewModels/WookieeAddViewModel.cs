using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SuiviDesWookiees.Libs;

namespace SuiviDesWookiees.UI.Mobile.ViewModels
{
    public partial class WookieeAddViewModel : ObservableObject
    {
        [ObservableProperty]
        private Wookiee wookiee;

        [RelayCommand]
        public async Task SaveOne()
        {

        }

    }
}
