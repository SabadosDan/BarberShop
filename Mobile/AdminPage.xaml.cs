using Mobile.Utils;

namespace Mobile;

public partial class AdminPage : ContentPage
{
	public AdminPage()
	{
		InitializeComponent();
	}

    private async void OnLogoutClicked(object sender, EventArgs e)
    {
        sessionManager.Logout();

        await Navigation.PushAsync(new LoginPage());
    }

    private async void OnViewBarbersClicked(object sender, EventArgs e)
    {
        if (sessionManager.Role == "Admin")
        {
         
            await Navigation.PushAsync(new AdminBarbersDashboard());
        }
        else
        {
            await Navigation.PushAsync(new BarbersPage());
        }
    }

    private async void OnAddSericeToBarberClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddServicePage());
    }

    private async void OnAddBarberClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddBarberPage());
    }

}