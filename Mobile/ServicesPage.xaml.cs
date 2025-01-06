using Mobile.Utils;

namespace Mobile;

public partial class ServicesPage : ContentPage
{
	public ServicesPage()
	{
		InitializeComponent();
	}

    private async void OnLogoutClicked(object sender, EventArgs e)
    {
        sessionManager.Logout();

        await Navigation.PushAsync(new LoginPage());
    }

}