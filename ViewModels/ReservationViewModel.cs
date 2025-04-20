using RestaurantApp.Services;
using RestaurantApp.Data.Models;
using System.Collections.ObjectModel;

namespace RestaurantApp.ViewModels;

public class ReservationViewModel
{
    public ObservableCollection<Reservation> Reservations { get; set; } = new();
    private readonly DataService _service = new();

    public ReservationViewModel()
    {
        LoadReservations();
    }

    private async void LoadReservations()
    {
        var reservationsFromDb = await _service.GetReservationsAsync();
        foreach (var res in reservationsFromDb)
        {
            Reservations.Add(res);
        }
    }
}
