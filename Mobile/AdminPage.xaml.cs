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
}