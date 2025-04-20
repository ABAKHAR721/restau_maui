using RestaurantApp.Data.Models;
using RestaurantApp.Data.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Maui.Storage;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantApp.Services;

public class DataService
{
    private readonly AppDbContext _context;

    public DataService()
    {
        // ✅ Build SQLite DB path using MAUI's local folder
        var dbPath = Path.Combine(FileSystem.AppDataDirectory, "restaurant.db");
        _context = new AppDbContext(dbPath);

        // ✅ Create DB and tables if not already created
        _context.Database.EnsureCreated();

        // 🌱 Seed data if empty
        if (!_context.Plats.Any())
        {
            _context.Plats.AddRange(
                new Plat { Nom = "Pizza", Description = "Fromage, tomate", Prix = 80, Categorie = "Italien" },
                new Plat { Nom = "Sushi", Description = "Poisson cru", Prix = 120, Categorie = "Japonais" }
            );
            _context.SaveChanges();
        }
    }

    public async Task<List<Plat>> GetPlatsAsync()
    {
        return await _context.Plats.ToListAsync();
    }

    public async Task AddPlatAsync(Plat plat)
    {
        _context.Plats.Add(plat);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Commande>> GetCommandesAsync()
    {
        return await _context.Commandes.ToListAsync();
    }

    public async Task<List<Reservation>> GetReservationsAsync()
    {
        return await _context.Reservations.ToListAsync();
    }
    public async Task AddCommandeAsync(Commande commande)
    {
        _context.Commandes.Add(commande);
        await _context.SaveChangesAsync();
    }
    public async Task AddReservationAsync(Reservation reservation)
    {
        _context.Reservations.Add(reservation);
        await _context.SaveChangesAsync();
    }
    public async Task DeletePlatAsync(Plat plat)
    {
        _context.Plats.Remove(plat);
        await _context.SaveChangesAsync();
    }   
    public async Task DeleteCommandeAsync(Commande commande)
    {
        _context.Commandes.Remove(commande);
        await _context.SaveChangesAsync();
    }
    public async Task DeleteReservationAsync(Reservation reservation)
    {
        _context.Reservations.Remove(reservation);
        await _context.SaveChangesAsync();
    }
    public async Task UpdatePlatAsync(Plat plat)
    {
        _context.Plats.Update(plat);
        await _context.SaveChangesAsync();
    }
    public async Task UpdateCommandeAsync(Commande commande)
    {
        _context.Commandes.Update(commande);
        await _context.SaveChangesAsync();
    }
    public async Task UpdateReservationAsync(Reservation reservation)
    {
        _context.Reservations.Update(reservation);
        await _context.SaveChangesAsync();
    }
    public async Task<Plat> GetPlatByIdAsync(int id)
    {
        return await _context.Plats.FindAsync(id);
    }
    public async Task<Commande> GetCommandeByIdAsync(int id)
    {
        return await _context.Commandes.FindAsync(id);
    }
    public async Task<Reservation> GetReservationByIdAsync(int id)
    {
        return await _context.Reservations.FindAsync(id);
    }
    public async Task<List<Plat>> GetPlatsByCategorieAsync(string categorie)
    {
        return await _context.Plats.Where(p => p.Categorie == categorie).ToListAsync();
    }


    public async Task<bool> RegisterUserAsync(Utilisateur user)
    {
        _context.Utilisateurs.Add(user);
        await _context.SaveChangesAsync();
        return true;
    }


    public async Task<Utilisateur?> LoginAsync(string email, string password)
    {
        return await _context.Utilisateurs.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
    }


}
