using System.Collections.ObjectModel; 
using RestaurantApp.Data.Models;
using RestaurantApp.Services;
using RestaurantApp.ViewModels;

namespace RestaurantApp.Helpers;

public static class AppData
{
    public static ObservableCollection<CommandeViewModel.CommandeItem> SharedCommande { get; set; } = new();
    public static CommandeViewModel CommandeVM { get; set; } = new();
    public static Commande CurrentCommande { get; set; } = new();
    public static DataService DataService { get; set; } = new();
    public static Utilisateur LoggedInUser { get; set; } = new();

}
