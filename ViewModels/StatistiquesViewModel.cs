using RestaurantApp.Data.Models;
using RestaurantApp.Services;
using System.ComponentModel;

namespace RestaurantApp.ViewModels;

public class StatistiquesViewModel : INotifyPropertyChanged
{
    private readonly DataService _service = new();

    public event PropertyChangedEventHandler? PropertyChanged;

    private int _nombreCommandes;
    public int NombreCommandes
    {
        get => _nombreCommandes;
        private set
        {
            if (_nombreCommandes != value)
            {
                _nombreCommandes = value;
                OnPropertyChanged(nameof(NombreCommandes));
            }
        }
    }

    private double _totalChiffreAffaires;
    public double TotalChiffreAffaires
    {
        get => _totalChiffreAffaires;
        private set
        {
            if (_totalChiffreAffaires != value)
            {
                _totalChiffreAffaires = value;
                OnPropertyChanged(nameof(TotalChiffreAffaires));
            }
        }
    }

    public StatistiquesViewModel()
    {
        LoadStats();
    }

    private async void LoadStats()
    {
        var commandes = await _service.GetCommandesAsync();
        NombreCommandes = commandes.Count;
        TotalChiffreAffaires = commandes.Sum(c => c.Total);
    }

    protected void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}
