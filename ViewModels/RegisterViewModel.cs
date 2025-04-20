using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RestaurantApp.Data.Models;
using RestaurantApp.Helpers;
using RestaurantApp.Services;

namespace RestaurantApp.ViewModels;

public partial class RegisterViewModel : ObservableObject
{
    private readonly DataService _dataService = AppData.DataService;

    [ObservableProperty] private string nom;
    [ObservableProperty] private string email;
    [ObservableProperty] private string password;
    [ObservableProperty] private string selectedRole = "client"; // default value

    [RelayCommand]
    public async Task RegisterAsync()
    {
        try
        {
            var user = new Utilisateur
            {
                Nom = Nom,
                Email = Email,
                Password = Password,
                Role = SelectedRole
            };

            await _dataService.RegisterUserAsync(user);

            AppData.LoggedInUser = user;
            Application.Current.MainPage = new AppShell(); // go to menu
        }
        catch (Exception ex)
        {
            await Application.Current.MainPage.DisplayAlert("Erreur", ex.Message, "OK");
        }
    }
}
