using Mobile.Utils;

namespace Mobile;

public partial class ServicesPage : ContentPage
{
    private BarberService barberService;
    public ServicesPage()
    {
        InitializeComponent();
        barberService = new BarberService();
    }

    private async void OnLogoutClicked(object sender, EventArgs e)
    {
        sessionManager.Logout();

        await Navigation.PushAsync(new LoginPage());
    }

    private async void OnViewBarbersClicked(object sender, EventArgs e)
    {
        if (sessionManager.Role == "Admin")
        {

            await Navigation.PushAsync(new AdminBarbersDashboard());
        }
        else
        {
            await Navigation.PushAsync(new BarbersPage());
        }
    }

    public async void OnViewAppointmentsClicked(object sender, EventArgs e)
    {
        // Verifică dacă utilizatorul este autentificat și are un ID
        var userId = sessionManager.UserId;
        if (userId == null)
        {
            await DisplayAlert("Error", "Nu ești autentificat!", "OK");
            return;
        }

        try
        {
            // Încărcați programările utilizatorului pe baza ID-ului
            var appointments = await barberService.GetAppointmentsByClientIdAsync(userId);

            if (appointments.Any())
            {
                // Navigați către o pagină care afișează programările
                await Navigation.PushAsync(new AppointmentsPage(appointments));
            }
            else
            {
                await DisplayAlert("No appointments", "You don't have any upcoming appointments.", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "There was an error loading your appointments: " + ex.Message, "OK");
        }


    }
}