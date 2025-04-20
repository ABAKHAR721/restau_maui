using RestaurantApp.ViewModels;
using RestaurantApp.Helpers;
namespace RestaurantApp.Pages;

public partial class CommandePage : ContentPage
{
    public CommandePage()
    {
        InitializeComponent();
        BindingContext = AppData.CommandeVM; // ✅ Shared ViewModel
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        AppData.CommandeVM.Refresh();
    }
}



