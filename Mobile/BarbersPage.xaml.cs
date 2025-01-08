using Mobile.Utils;
using System.Net.Http;
using System.Net.Http.Json;
using WebAPI.Models;

namespace Mobile;

public partial class BarbersPage : ContentPage
{
    private readonly BarberService barberService;
    private readonly ReviewService _reviewService;
    private readonly HttpClient _httpClient;
	public BarbersPage()
	{
		InitializeComponent();
        barberService = new BarberService();
        _reviewService = new ReviewService();
        _httpClient = new HttpClient();
        LoadBarbers();
 
    }

    private async void LoadBarbers()
    {
        try
        {
            var barbers = await barberService.GetBarbersWithServicesAsync();

            if (barbers == null || !barbers.Any())
            {
                throw new Exception("No barbers found.");
            }

            BarbersListView.ItemsSource = barbers;

            foreach (var barber in barbers)
            {
                var response = await _reviewService.GetAverageRatingAsync(barber.Id);

                Console.WriteLine(response.Value);

                barber.AverageRating = response.Value;
            }
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

    private async void OnGiveFeedbackClicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var barber = (button?.BindingContext as Barber);

        if (barber != null)
        {
            await Navigation.PushAsync(new BarberRatingPage(barber.Id));
        }
    }

    private async void OnSeeReviewsClicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var barber = (button?.BindingContext as Barber);

        if (barber != null)
        {
            await Navigation.PushAsync(new BarberReviewsPage(barber.Id));
        }
    }


}