namespace RestaurantApp.Models;

public class Reservation
{
    public int Id { get; set; }
    public required string NomClient { get; set; }
    public DateTime DateHeure { get; set; }
    public int NombrePersonnes { get; set; }
}
