using Newtonsoft.Json;
using WebAPI.Models;

namespace Mobile;

public partial class AdminBarbersDashboard : ContentPage
{

    private static readonly string ApiUrl = DeviceInfo.Platform == DevicePlatform.Android
  ? "http://10.0.2.2:5145"
  : "http://localhost:5145";

    public AdminBarbersDashboard()
	{
		InitializeComponent();
        LoadBarbers();

    }

    private async void LoadBarbers()
    {
        using (var client = new HttpClient())
        {
            try
            {
                var response = await client.GetStringAsync($"{ApiUrl}/api/Barbers");
                var barbers = JsonConvert.DeserializeObject<List<Barber>>(response);
                BarbersCollectionView.ItemsSource = barbers;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "Failed to load barbers: " + ex.Message, "OK");
            }
        }
    }

    private async void OnEditBarberClicked(object sender, EventArgs e)
    {
        var button = (Button)sender;
        var barber = button.BindingContext as Barber;
        if (barber != null)
        {
            await Navigation.PushAsync(new EditBarberPage(barber));
        }
    }

    private async void OnDeleteBarberClicked(object sender, EventArgs e)
    {
        var button = (Button)sender;
        var barber = button.BindingContext as Barber;
        if (barber != null)
        {
            await DeleteBarber(barber.Id);
        }
    }

    private async Task DeleteBarber(int barberId)
    {
        using (var client = new HttpClient())
        {
            var response = await client.DeleteAsync($"{ApiUrl}/api/Barbers");
            if (response.IsSuccessStatusCode)
            {
                await DisplayAlert("Success", "Barber deleted successfully", "OK");
                LoadBarbers();
            }
            else
            {
                await DisplayAlert("Error", "Failed to delete barber", "OK");
            }
        }
    }

}