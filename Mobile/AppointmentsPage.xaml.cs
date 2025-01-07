using WebAPI.Models;

namespace Mobile;

public partial class AppointmentsPage : ContentPage
{
	public AppointmentsPage(List<Appointment> appointments)
	{
		InitializeComponent();
		AppointmentsCollectionView.ItemsSource = appointments;
	}

	
}