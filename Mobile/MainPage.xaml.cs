using Microsoft.Maui.Controls;

namespace Mobile
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }


        private async void OnRegisterClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage());
        }

        private void OnVeziServiciiClicked(object sender, EventArgs e)
        {
            
        }

        private void OnContacteazaClicked(object sender, EventArgs e)
        {

        }
    }

}
