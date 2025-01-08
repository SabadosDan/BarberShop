using Newtonsoft.Json;
using System.Text;
using WebAPI.Models;

namespace Mobile;

public partial class AddBarberPage : ContentPage
{
    private static readonly string ApiUrl = DeviceInfo.Platform == DevicePlatform.Android
    ? "http://10.0.2.2:5145"
    : "http://localhost:5145";
    public AddBarberPage()
	{
		InitializeComponent();
	}

    private async void OnAddBarberClicked(object sender, EventArgs e)
    {
        var newBarber = new Barber
        {
            FirstName = FirstNameEntry.Text,
            LastName = LastNameEntry.Text,
            PhoneNumber = PhoneNumberEntry.Text,
            Specialization = SpecializationEntry.Text,
            Services = new List<Service>()
        };

        using (var client = new HttpClient())
        {
            var json = JsonConvert.SerializeObject(newBarber);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"{ApiUrl}/api/Barbers", content);

            if (response.IsSuccessStatusCode)
            {
                await DisplayAlert("Success", "Barber added successfully", "OK");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Error", "Failed to add barber", "OK");
            }
        }
    }


}