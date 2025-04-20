namespace RestaurantApp.Services;

public class NotificationService
{
    public static async Task Envoyer(string message)
    {
        await Application.Current.MainPage.DisplayAlert("Notification", message, "OK");
    }
}
