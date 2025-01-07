using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text;
using WebAPI.Models;

namespace Mobile;

public partial class EditBarberPage : ContentPage
{

    private static readonly string ApiUrl = DeviceInfo.Platform == DevicePlatform.Android
  ? "http://10.0.2.2:5145"
  : "http://localhost:5145";
    public EditBarberPage(Barber barber)
    {
        InitializeComponent();

        IdEntry.Text = barber.Id.ToString();
        FirstNameEntry.Text = barber.FirstName;
        LastNameEntry.Text = barber.LastName;
        PhoneNumberEntry.Text = barber.PhoneNumber;
        SpecializationEntry.Text = barber.Specialization;
    }

    private async void OnSaveChangesClicked(object sender, EventArgs e)
    {
        var updatedBarber = new Barber
        {
            Id = int.Parse(IdEntry.Text),
            FirstName = FirstNameEntry.Text,
            LastName = LastNameEntry.Text,
            PhoneNumber = PhoneNumberEntry.Text,
            Specialization = SpecializationEntry.Text
        };

        using (var client = new HttpClient())
        {
            var json = JsonConvert.SerializeObject(updatedBarber);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"{ApiUrl}/api/Barbers/{updatedBarber.Id}", content);

            if (response.IsSuccessStatusCode)
            {
                await DisplayAlert("Success", "Barber updated successfully", "OK");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Error", "Failed to update barber", "OK");
            }
        }


    }
}