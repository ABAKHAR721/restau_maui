using RestaurantApp.ViewModels;

namespace RestaurantApp.Pages;

public partial class ReservationPage : ContentPage
{
    public ReservationPage()
    {
        InitializeComponent();
        BindingContext = new ReservationViewModel();
    }
}
