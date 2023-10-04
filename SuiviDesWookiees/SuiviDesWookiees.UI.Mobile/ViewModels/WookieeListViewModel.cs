using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace SuiviDesWookiees.UI.Mobile.ViewModels
{
    public partial class WookieeListViewModel : ObservableObject
    {
        // public ObservableCollection<SuiviDesWookiees.Libs.Wookiee> List { get; set; }
        [ObservableProperty]
        private ObservableCollection<SuiviDesWookiees.Libs.Wookiee> wookiees;
    }
}
