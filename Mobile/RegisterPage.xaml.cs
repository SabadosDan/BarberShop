using Mobile.Models;
using Newtonsoft.Json;
using System.Text;
using System.Text.RegularExpressions;

namespace Mobile;

public partial class RegisterPage : ContentPage
{
    private static readonly string ApiUrl = DeviceInfo.Platform == DevicePlatform.Android
    ? "http://10.0.2.2:5145"
    : "http://localhost:5145";
    public RegisterPage()
	{
		InitializeComponent();
	}
    private async void OnRegisterClicked(object sender, EventArgs e)
    {
        var firstName = CapitalizeFirstLetter(FirstNameEntry.Text);
        var lastName = CapitalizeFirstLetter(LastNameEntry.Text);
        var phoneNumber = PhoneNumberEntry.Text;
        var password = PasswordEntry.Text;


        if (string.IsNullOrEmpty(firstName))
        {
            await DisplayAlert("Error", "First name is required.", "OK");
            return;
        }

        if (string.IsNullOrEmpty(lastName))
        {
            await DisplayAlert("Error", "Last name is required.", "OK");
            return;
        }

        if (string.IsNullOrEmpty(password) || password.Length < 6)
        {
            await DisplayAlert("Error", "Password must be at least 6 characters long.", "OK");
            return;
        }

        if (string.IsNullOrEmpty(phoneNumber) || !Regex.IsMatch(phoneNumber, @"^\d{10}$"))
        {
            await DisplayAlert("Error", "Phone number must be exactly 10 digits.", "OK");
            return;
        }

        var client = new Clients
        {
            FirstName = firstName,
            LastName = lastName,
            PhoneNumber = phoneNumber,
            Password = password,
            Role = "Client"
        };

        await RegisterClientAsync(client);
    }

    
    private async Task RegisterClientAsync(Clients client)
    {
        using (var httpClient = new HttpClient())
        {
            try
            {
                var jsonContent = JsonConvert.SerializeObject(client);

                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync($"{ApiUrl}/api/Clients", content);

                if (response.IsSuccessStatusCode)
                {
                    await DisplayAlert("Success", "Client registered successfully!", "OK");

                    // await Navigation.PushAsync(new LoginPage());
                }
                else
                {
                    var errorMessage = await response.Content.ReadAsStringAsync();
                    await DisplayAlert("Error", $"Registration failed: {errorMessage}", "OK");
                }
            }
            catch (Exception ex)
            {    
                await DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
            }
        }
    }

    private string CapitalizeFirstLetter(string input)
    {
        if (string.IsNullOrEmpty(input))
            return input;

        return char.ToUpper(input[0]) + input.Substring(1).ToLower();
    }

}