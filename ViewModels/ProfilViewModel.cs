using RestaurantApp.Models;

namespace RestaurantApp.ViewModels;

public class ProfilViewModel
{
    public Utilisateur Utilisateur { get; set; } = new Utilisateur
    {
        Nom = "Admin",
        Email = "admin@restaurant.com",
        Role = "Employe"
    };
}
