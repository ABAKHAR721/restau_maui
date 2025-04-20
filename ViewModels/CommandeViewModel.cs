using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RestaurantApp.Data.Models;
using RestaurantApp.Services;
using RestaurantApp.Helpers;
using System.Collections.ObjectModel;

namespace RestaurantApp.ViewModels;

public partial class CommandeViewModel : ObservableObject
{
    private readonly DataService _dataService = AppData.DataService;

    public class CommandeItem
    {
        public Plat Plat { get; set; }
        public int Quantite { get; set; } = 1;

        public double Total => Plat != null ? Plat.Prix * Quantite : 0;
    }

    public ObservableCollection<CommandeItem> Commande { get; } = new();

    [ObservableProperty]
    private double total;

    [ObservableProperty]
    private string message;

    [ObservableProperty]
    private bool messageVisible;

    public CommandeViewModel()
    {
        Refresh();
    }

    public void AddToCommande(Plat plat)
    {
        try
        {
            if (plat == null || plat.Id == 0 || string.IsNullOrWhiteSpace(plat.Nom)) // ✅ validation
            {
                _ = ShowError(new Exception("Plat invalide, impossible d'ajouter à la commande."));
                return;
            } 

            if (plat == null)
                return;

            var existing = Commande.FirstOrDefault(ci => ci.Plat.Id == plat.Id);
            if (existing != null)
            {
                existing.Quantite++;
            }
            else
            {
                Commande.Add(new CommandeItem { Plat = plat, Quantite = 1 });
            }

            RecalculateTotal();
        }
        catch (Exception ex)
        {
            ShowError(ex);
        }
    }

    private void RecalculateTotal()
    {
        Total = Commande.Sum(ci => ci.Total);
    }

    public void Refresh()
    {
        OnPropertyChanged(nameof(Commande));
        RecalculateTotal();
    }

    [RelayCommand]
    public async Task ValiderCommandeAsync()
    {
        try
        {
            if (Commande == null)
            {
                await ShowError(new Exception("❌ Commande collection is null."));
                return;
            }

            if (!Commande.Any())
            {
                Message = "La commande est vide.";
                MessageVisible = true;
                return;
            }

            foreach (var item in Commande)
            {
                if (item == null)
                {
                    await ShowError(new Exception("❌ An item in the commande list is null."));
                    return;
                }

                if (item.Plat == null)
                {
                    await ShowError(new Exception("❌ Plat in a commande item is null."));
                    return;
                }
            }

            var newCommande = new Commande
            {
                Plats = Commande
                    .Where(ci => ci.Plat != null)
                    .SelectMany(ci => Enumerable.Repeat(ci.Plat, ci.Quantite))
                    .ToList(),
                Date = DateTime.Now
            };

            await _dataService.AddCommandeAsync(newCommande);

            Message = "✅ Commande enregistrée !";
            MessageVisible = true;

            Commande.Clear();
            RecalculateTotal();
        }
        catch (Exception ex)
        {
            await ShowError(ex);
        }
    }

    private async Task ShowError(Exception ex)
    {
        var fullMessage = ex.Message;
        if (ex.InnerException != null)
            fullMessage += "\n" + ex.InnerException.Message;

        if (Application.Current?.MainPage != null)
            await Application.Current.MainPage.DisplayAlert("Erreur", fullMessage, "OK");
    }

}
