using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Tr1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        // Método para manejar el toque en el icono de búsqueda
        private async void HandleSearchTapped(object sender, EventArgs e)
        {
            // Implementa la lógica de búsqueda aquí
            await DisplayAlert("Búsqueda", "Realizando búsqueda...", "Aceptar");
        }

        // Método para manejar el toque en el icono de menú desplegable
        private async void HandleMenuTapped(object sender, EventArgs e)
        {
            // Implementa la lógica del menú desplegable aquí
            await DisplayAlert("Menú", "Mostrando menú desplegable...", "Aceptar");
        }

        // Método para manejar el clic del botón "+"
        private void HandleAddClicked(object sender, EventArgs e)
        {
            // Implementa la lógica para el botón "+"
        }
        private void HandleCheckTapped(object sender, EventArgs e)
        {

        }
        private void MostrarOcultarLista(object sender, EventArgs e)
        {
           listaActividadesFrame.IsVisible = !listaActividadesFrame.IsVisible;
        }
        private void ActividadSeleccionada(object sender, EventArgs e)
        {

        }
    }
}