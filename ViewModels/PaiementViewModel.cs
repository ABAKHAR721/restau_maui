namespace RestaurantApp.ViewModels;

public class PaiementViewModel
{
    [Obsolete]
    public async Task EffectuerPaiement(double montant)
    {
        await Application.Current.MainPage.DisplayAlert("Paiement", $"Paiement de {montant} MAD effectué avec succès.", "OK");
    }
}
