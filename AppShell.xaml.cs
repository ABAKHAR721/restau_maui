using RestaurantApp.Helpers;
namespace RestaurantApp;
public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        if (AppData.LoggedInUser?.Role == "admin")
        {
            AddPlatShell.IsVisible = true;
        }
    }
}

