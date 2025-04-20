using RestaurantApp.ViewModels;

namespace RestaurantApp.Pages;

public partial class PaiementPage : ContentPage
{
    public PaiementPage()
    {
        InitializeComponent();
        BindingContext = new PaiementViewModel();
    }
}
