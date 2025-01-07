using Mobile.Utils;
using WebAPI.Models;

namespace Mobile;

public partial class BarbersPage : ContentPage
{
    private BarberService barberService;
	public BarbersPage()
	{
		InitializeComponent();
        barberService = new BarberService();
        LoadBarbers();

    }

    private async void LoadBarbers()
    {
        try
        {
            var barbers = await barberService.GetBarbersWithServicesAsync();

            foreach (var barber in barbers)
            {
                Console.WriteLine($"Name: {barber.FirstName} {barber.LastName}");
                Console.WriteLine($"Specialization: {barber.Specialization}");
                Console.WriteLine($"Phone: {barber.PhoneNumber}");
            }

            if (barbers == null || !barbers.Any())
            {
                throw new Exception("No barbers found.");
            }

            BarbersListView.ItemsSource = barbers;
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "Failed to load barbers: " + ex.Message, "OK");
        }
    }

    private async void OnSeeServicesClicked(object sender, EventArgs e)
    {
        
        var barber = (sender as Button)?.BindingContext as Barber;

        if (barber != null)
        {
            await Navigation.PushAsync(new ShowBarberServices(barber.Id));
        }
    }

}