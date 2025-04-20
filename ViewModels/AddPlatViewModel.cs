using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RestaurantApp.Data.Models;
using RestaurantApp.Services;
using System.Collections.ObjectModel;

namespace RestaurantApp.ViewModels;

public partial class AddPlatViewModel : ObservableObject
{
    private readonly DataService _dataService = new();

    [ObservableProperty] private string nom;
    [ObservableProperty] private string description;
    [ObservableProperty] private string prix;
    [ObservableProperty] private string categorie;

    public ObservableCollection<string> Categories { get; } = new() { "Italien", "Japonais", "Marocain", "Libanais" };

    [ObservableProperty] private string message;
    [ObservableProperty] private bool messageVisible;

    [RelayCommand]
    public async Task AjouterPlatAsync()
    {
        if (string.IsNullOrWhiteSpace(Nom) || string.IsNullOrWhiteSpace(Prix))
        {
            Message = "Tous les champs sont requis.";
            MessageVisible = true;
            return;
        }

        var plat = new Plat
        {
            Nom = Nom,
            Description = Description,
            Prix = double.TryParse(Prix, out var parsed) ? parsed : 0,
            Categorie = Categorie
        };

        await _dataService.AddPlatAsync(plat);

        Message = "✅ Plat ajouté avec succès !";
        MessageVisible = true;

        // Clear form
        Nom = Description = Prix = Categorie = string.Empty;
    }
}
