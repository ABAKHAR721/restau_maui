using RestaurantApp.ViewModels;

namespace RestaurantApp.Pages;

public partial class MenuPage : ContentPage
{
    private readonly MenuViewModel _viewModel;

    public MenuPage()
    {
        InitializeComponent();
        _viewModel = new MenuViewModel();
        BindingContext = _viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _viewModel.LoadPlatsAsync(); // ✅ works now!
    }
}
