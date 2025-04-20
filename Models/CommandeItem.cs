using CommunityToolkit.Mvvm.ComponentModel;
using RestaurantApp.Data.Models;

namespace RestaurantApp.Models
{
    public partial class CommandeItem : ObservableObject
    {
        public Plat Plat { get; set; }

        [ObservableProperty]
        private int quantite = 1;

        public double Total => Plat.Prix * Quantite;
    }
}
