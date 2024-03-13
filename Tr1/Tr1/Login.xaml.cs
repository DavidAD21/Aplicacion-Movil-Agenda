using System;
using Xamarin.Forms;

namespace Tr1
{
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }

        private async void HandleLoginClicked(object sender, EventArgs e)
        {
 
            string username = entryUsername.Text;
            string password = entryPassword.Text;

            
            string storedUsername = Application.Current.Properties.ContainsKey("Username") ? Application.Current.Properties["Username"].ToString() : "";
            string storedPassword = Application.Current.Properties.ContainsKey("Password") ? Application.Current.Properties["Password"].ToString() : "";

            if (username == storedUsername && password == storedPassword)
            {
        
                await Navigation.PushAsync(new MainPage());
            }
            else if (username == storedUsername)
            {
              
                await DisplayAlert("Error", "Contraseña incorrecta", "Aceptar");
            }
            else if (password == storedPassword)
            {
               
                await DisplayAlert("Error", "Usuario incorrecto", "Aceptar");
            }
            else
            {
              
                await DisplayAlert("Error", "Credenciales incorrectas", "Aceptar");
            }
        }

        private async void HandleRegisterTapped(object sender, EventArgs e)
        {
           
            await Navigation.PushAsync(new Register());
        }

    }
}
