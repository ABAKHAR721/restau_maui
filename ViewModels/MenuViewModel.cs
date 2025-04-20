using System.Collections.ObjectModel;
using System.Windows.Input;
using RestaurantApp.Data.Models;
using RestaurantApp.Services;
using RestaurantApp.Helpers;

namespace RestaurantApp.ViewModels;

public class MenuViewModel
{
    private readonly DataService _dataService = AppData.DataService;

    public ObservableCollection<Plat> Plats { get; set; } = new();

    public ICommand AddToCommandeCommand { get; }

    public MenuViewModel()
    {
        AddToCommandeCommand = new Command<Plat>(AddToCommande);
        _ = LoadPlatsAsync();
    }

    public async Task LoadPlatsAsync()
    {
        Plats.Clear();
        var platsFromDb = await _dataService.GetPlatsAsync();
        foreach (var plat in platsFromDb)
            Plats.Add(plat);
    }
        private void AddToCommande(Plat plat){
            if (plat != null)
            {
                AppData.CommandeVM.AddToCommande(plat); // ✅ Add to shared instance
            }
        }

    public void Refresh()
    {
        LoadPlatsAsync().Wait();
    }
    public static void ClearCommande()
    {
        AppData.CurrentCommande.Plats.Clear();
    }

}
