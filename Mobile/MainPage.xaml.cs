using Microsoft.Maui.Controls;
using Mobile.Utils;

namespace Mobile
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnVeziServiciiClicked(object sender, EventArgs e)
        {
            if (sessionManager.IsLoggedIn)
            {
                Navigation.PushAsync(new ServicesPage());
            }
            else
            {
                Navigation.PushAsync(new LoginPage());
            }
        }

        private void OnContacteazaClicked(object sender, EventArgs e)
        {

        }
    }

}
