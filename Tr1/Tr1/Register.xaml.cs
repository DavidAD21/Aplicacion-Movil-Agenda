using Acr.UserDialogs;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tr1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Register : ContentPage
    {
        public Register()
        {
            InitializeComponent();
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            // Navegar a la página de inicio de sesión si el usuario ya tiene una cuenta
            await Navigation.PushAsync(new Login());
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            // Obtener la información ingresada por el usuario
            string username = entryUsername.Text;
            string email = entryEmail.Text;
            string password = entryPassword.Text;

            // Guardar las credenciales en el almacenamiento de la aplicación
            Application.Current.Properties["Username"] = username;
            Application.Current.Properties["Email"] = email;
            Application.Current.Properties["Password"] = password;

            // Guardar los cambios
            await Application.Current.SavePropertiesAsync();
            UserDialogs.Instance.ShowLoading("Registrando usuario...");
            await Task.Delay(3000);
            UserDialogs.Instance.HideLoading();
            // Mostrar alerta de registro exitoso
            await DisplayAlert("Registro exitoso", $"Nombre de usuario: {username}\nEmail: {email}\nContraseña: {password}", "Aceptar");

            // Navegar a la página de inicio de sesión
            await Navigation.PushAsync(new Login());
        }
    }
}