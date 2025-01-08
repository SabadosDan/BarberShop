using Mobile.Utils;
using Newtonsoft.Json;
using System.Text;

namespace Mobile;

public partial class LoginPage : ContentPage
{

    private static readonly string ApiUrl = DeviceInfo.Platform == DevicePlatform.Android
    ? "http://10.0.2.2:5145"
    : "http://localhost:5145";

    public LoginPage()
	{
		InitializeComponent();
	}

    private async void OnRegisterClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RegisterPage());
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        var phoneNumber = PhoneNumberEntry.Text;
        var password = PasswordEntry.Text;

        if (string.IsNullOrEmpty(phoneNumber) || string.IsNullOrEmpty(password))
        {
            await DisplayAlert("Error", "Please fill in all fields.", "OK");
            return;
        }

        int userId = await VerifyLogin(phoneNumber, password);

        if (userId > 0)
        {
            await DisplayAlert("Success", "Logged in successfully!", "OK");

            if (sessionManager.Role == "Admin")
            {
                await Navigation.PushAsync(new AdminPage());
            }
            else
            {
                await Navigation.PushAsync(new ServicesPage());
            }
        }
        else
        {
            await DisplayAlert("Error", "Invalid credentials.", "OK");
        }
    }

    private async Task<int> VerifyLogin(string phoneNumber, string password)
    {
        var loginRequest = new
        {
            PhoneNumber = phoneNumber,
            Password = password
        };

        var jsonContent = JsonConvert.SerializeObject(loginRequest);
        var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

        using (var httpClient = new HttpClient())
        {
            try
            {
                var response = await httpClient.PostAsync($"{ApiUrl}/api/Auth/Login", content);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var loginResponse = JsonConvert.DeserializeObject<LoginResponse>(result);

                    sessionManager.UserId = loginResponse.UserId;
                    sessionManager.Role = loginResponse.Role;
                    sessionManager.IsLoggedIn = true;

                    return loginResponse.UserId;
                }
                else
                {
                    Console.WriteLine($"Login failed. Status code: {response.StatusCode}");
                    return -1;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return -1;
            }
        }
    }


}