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

        private async void Ingresar_Clicked(object sender, EventArgs e)
        {
            string username = TxtUsuario.Text;
            string password = TxtPassword.Text;

            // Verificar si el nombre de usuario y la contraseña coinciden con los valores esperados
            if (username == "admin" && password == "admin")
            {
                // Las credenciales son válidas, navegar a la página MainPage
                await Navigation.PushAsync(new MainPage());
            }
            else
            {
                await DisplayAlert("Alerta", "El usuario o la contraseña es incorrecta", "OK");
            }
        }

        private async void Registro_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Register());
        }
    }
}
