using Newtonsoft.Json;
using System.Text;
using WebAPI.Models;

namespace Mobile;

public partial class EditServicePage : ContentPage
{

    private static readonly string ApiUrl = DeviceInfo.Platform == DevicePlatform.Android
  ? "http://10.0.2.2:5145"
  : "http://localhost:5145";

    public EditServicePage(Service service)
    {
        InitializeComponent();


        IdEntry.Text = service.Id.ToString();
        ServiceNameEntry.Text = service.Name;
        PriceEntry.Text = service.Price.ToString();
        DurationEntry.Text = service.Duration.TotalMinutes.ToString(); 
    }

    private async void OnSaveChangesClicked(object sender, EventArgs e)
    {
        var updatedService = new Service
        {
            Id = int.Parse(IdEntry.Text),  
            Name = ServiceNameEntry.Text,  
            Price = decimal.Parse(PriceEntry.Text),  
            Duration = TimeSpan.Parse(DurationEntry.Text),  
            BarberId = (BarberPicker.SelectedItem as Barber).Id 
        };

        using (var client = new HttpClient())
        {
            var json = JsonConvert.SerializeObject(updatedService);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"{ApiUrl}/api/Barbers", content);

            if (response.IsSuccessStatusCode)
            {
                await DisplayAlert("Success", "Service updated successfully", "OK");
                await Navigation.PopAsync(); 
            }
            else
            {
                await DisplayAlert("Error", "Failed to update service", "OK");
            }
        }
    }


}