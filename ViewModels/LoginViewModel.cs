using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RestaurantApp.Helpers;
using RestaurantApp.Services;
namespace RestaurantApp.ViewModels;

public partial class LoginViewModel : ObservableObject
{
    private readonly DataService _dataService = AppData.DataService;

    [ObservableProperty] private string email;
    [ObservableProperty] private string password;

    [RelayCommand]
    public async Task LoginAsync()
    {
        var user = await _dataService.LoginAsync(Email, Password);
        if (user != null)
        {
            AppData.LoggedInUser = user;
            await Shell.Current.GoToAsync("//menu");
        }
        else
        {
            await Shell.Current.DisplayAlert("Erreur", "Email ou mot de passe incorrect", "OK");
        }
    }
}
