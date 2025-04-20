namespace RestaurantApp.Models;

public class Commande
{
    public int Id { get; set; }
    public List<Plat> Plats { get; set; } = new();
    public DateTime Date { get; set; } = DateTime.Now;
    public double Total => Plats.Sum(p => p.Prix);
}
