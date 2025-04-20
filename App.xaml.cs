using RestaurantApp.Pages;

namespace RestaurantApp;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
    }

    //protected override Window CreateWindow(IActivationState? activationState)
    //{
    //    // 👇 Set the initial page to LoginPage wrapped in NavigationPage
    //    return new Window(new NavigationPage(new LoginPage()));
    //}
protected override Window CreateWindow(IActivationState? activationState)
    {
        return new Window(new AppShell());
    }
}
