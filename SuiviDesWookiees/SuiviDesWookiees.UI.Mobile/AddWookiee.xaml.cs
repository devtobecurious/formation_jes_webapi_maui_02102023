namespace SuiviDesWookiees.UI.Mobile;

[QueryProperty(nameof(DefaultPower), "defaultPower")]
public partial class AddWookiee : ContentPage
{
    public AddWookiee()
    {
        InitializeComponent();
    }

    public int DefaultPower { get; set; }
}