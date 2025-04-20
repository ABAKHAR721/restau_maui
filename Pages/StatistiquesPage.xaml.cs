using RestaurantApp.ViewModels;

namespace RestaurantApp.Pages;

public partial class StatistiquesPage : ContentPage
{
    public StatistiquesPage()
    {
        InitializeComponent();
        BindingContext = new StatistiquesViewModel();
    }
}
