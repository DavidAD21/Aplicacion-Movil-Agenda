using System;
﻿using Acr.UserDialogs;
using System;
using System.Threading.Tasks;

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
       private async void HandleLoginClicked(object sender, EventArgs e)
        {
 
            string username = entryUsername.Text;
            string password = entryPassword.Text;

            
            string storedUsername = Application.Current.Properties.ContainsKey("Username") ? Application.Current.Properties["Username"].ToString() : "";
            string storedPassword = Application.Current.Properties.ContainsKey("Password") ? Application.Current.Properties["Password"].ToString() : "";

            if (username == storedUsername && password == storedPassword)
            {
                UserDialogs.Instance.ShowLoading("Iniciando sesión...");
                await Task.Delay(3000);
                UserDialogs.Instance.HideLoading();
                await Navigation.PushAsync(new MainPage());
              
            }

            else if (username == storedUsername)
            {
                UserDialogs.Instance.ShowLoading("dsa...");
                await DisplayAlert("Error", "Contraseña incorrecta", "Aceptar");
            }
            else if (password == storedPassword)
            {
                UserDialogs.Instance.ShowLoading("aaaaaa..");
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
