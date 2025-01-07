using Mobile.Utils;
using WebAPI.Models;

namespace Mobile
{
    public partial class ShowBarberServices : ContentPage
    {
        private BarberService barberService;
        private int BarberId { get; set; }

        private HttpClient httpClient;
        private ClientManager clientManager;
        public ShowBarberServices(int barberId)
        {
            InitializeComponent();

            BarberId = barberId;
            barberService = new BarberService();
            clientManager = new ClientManager();
            BindingContext = new
            {
                MinimumDate = DateTime.Now,
                MaximumDate = DateTime.Now.AddMonths(1) // Poți ajusta după nevoi
            };
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
                DateTime selectedDate = DatePicker.Date;
                TimeSpan selectedTime = TimePicker.Time;
                DateTime selectedDateTime = selectedDate.Add(selectedTime);


                bool isAvailable = await barberService.CheckAvailability(BarberId, selectedDateTime);

                if (isAvailable)
                {
                    decimal totalPrice = selectedServices.Sum(service => service.Price);
                    List<string> serviceNames = selectedServices.Select(service => service.Name).ToList();
                    var client = await clientManager.GetClientByIdAsync(sessionManager.UserId);
                    Appointment appointment = new Appointment
                    {
                        BarberId = BarberId,
                        DateTime = selectedDateTime,
                        ClientName = client.FirstName,
                        ClientPhone = client.PhoneNumber,
                       Services = serviceNames,
                        Price = totalPrice,
                        IsReserved = true
                    };

                    bool isBooked = await barberService.BookAppointment(appointment);

                    if (isBooked)
                    {
                        await DisplayAlert("Success", "Your appointment has been successfully booked.", "OK");
                    }
                    else
                    {
                        await DisplayAlert("Error", "There was an issue booking your appointment.", "OK");
                    }
                }
                else
                {
                    await DisplayAlert("Not Available", "This time slot is already booked.", "OK");
                }
            }
            else
            {
                await DisplayAlert("Error", "Please select at least one service.", "OK");
            }
        }


        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedServices = ServicesCollectionView.SelectedItems.Cast<Service>().ToList();
            decimal totalPrice = selectedServices.Sum(service => service.Price);

            TotalPriceLabel.Text = $"Total: {totalPrice} Lei";
        }



    }
}

