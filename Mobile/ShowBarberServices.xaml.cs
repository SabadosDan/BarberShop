using Mobile.Utils;
using WebAPI.Models;

namespace Mobile
{
    public partial class ShowBarberServices : ContentPage
    {
        private BarberService barberService;
        private int BarberId { get; set; }

        public ShowBarberServices(int barberId)
        {
            InitializeComponent();

            BarberId = barberId;
            barberService = new BarberService();
            LoadServices(barberId);
        }

        private async void LoadServices(int barberId)
        {
            try
            {
                var services = await barberService.GetServicesByBarberIdAsync(barberId);

                if (services.Any())
                {
                    ServicesCollectionView.ItemsSource = services;
                }
                else
                {
                    await DisplayAlert("Error", "No services found for this barber.", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }



        private async void OnBookServicesClicked(object sender, EventArgs e)
        {
            var selectedServices = ServicesCollectionView.SelectedItems.Cast<Service>().ToList();

            if (selectedServices.Any())
            {
                
                string servicesList = string.Join(", ", selectedServices.Select(s => s.Name));

               
                await DisplayAlert("Selected Services", $"You selected: {servicesList}", "OK");

                // Aici poți trimite selecția spre server pentru a rezerva serviciile
                // await SendReservationToServer(selectedServices);
            }
            else
            {
               
                await DisplayAlert("Error", "Please select at least one service.", "OK");
            }
        }
    }
}
