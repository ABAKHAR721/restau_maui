using RestaurantApp.ViewModels;

namespace RestaurantApp.Pages;

public partial class ProfilPage : ContentPage
{
    public ProfilPage()
    {
        InitializeComponent();
        BindingContext = new ProfilViewModel();
    }
}
