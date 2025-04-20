namespace RestaurantApp.Models;

public class Plat
{
    public int Id { get; set; }
    public string Nom { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public double Prix { get; set; }
    public string Categorie { get; set; } = string.Empty;
}
