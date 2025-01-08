using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text;
using WebAPI.Models;

namespace Mobile;

public partial class AddServicePage : ContentPage
{
    private static readonly string ApiUrl = DeviceInfo.Platform == DevicePlatform.Android
   ? "http://10.0.2.2:5145"
   : "http://localhost:5145";

    public AddServicePage()
	{
		InitializeComponent();
        
        LoadBarbers();

    }

    private async void LoadBarbers()
    {
        using (var client = new HttpClient())
        {
            var response = await client.GetAsync($"{ApiUrl}/api/Barbers");

            if (response.IsSuccessStatusCode)
            {
                var barbers = await response.Content.ReadFromJsonAsync<List<Barber>>();
                if (barbers == null || barbers.Count == 0)
                {
                    await DisplayAlert("Error", "No barbers found", "OK");
                }
                else
                {
                    BarberPicker.ItemsSource = barbers;
                }
            }
            else
            {
                await DisplayAlert("Error", "Failed to load barbers", "OK");
            }
        }
    }

    private async void OnAddServiceClicked(object sender, EventArgs e)
    {
        var selectedBarber = BarberPicker.SelectedItem as Barber;

        if (selectedBarber == null)
        {
            await DisplayAlert("Error", "Please select a barber.", "OK");
            return;
        }

        var newService = new Service
        {
            Name = ServiceNameEntry.Text,
            Price = decimal.Parse(PriceEntry.Text),
            Duration = TimeSpan.FromMinutes(int.Parse(DurationEntry.Text)),
            BarberId = selectedBarber?.Id,
        };


        var json = JsonConvert.SerializeObject(newService);

        using (var client = new HttpClient())
        {
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"{ApiUrl}/api/Services", content);

            if (response.IsSuccessStatusCode)
            {
                await DisplayAlert("Success", "Service added successfully", "OK");
                await Navigation.PopAsync();
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                await DisplayAlert("Error", $"Failed to add service: {errorContent}", "OK");
            }
        }
    }



}