namespace Mobile;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

	private void Login_CLicked(object sender, EventArgs e)
	{
		string userName = txtPhoneNumber.Text;
		string password = txtPassword.Text;

		if (userName == null || password == null)
		{
			DisplayAlert("Warning", "Please fill all the inputs!","OK");
			return;
		}
	}

	
}