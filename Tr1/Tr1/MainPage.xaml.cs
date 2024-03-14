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
            entryActividad.TextChanged += EntryActividad_TextChanged;
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
            var action = await DisplayActionSheet("Opciones", "Cancelar", null, "Configuración", "Tareas Múltiples");

            switch (action)
            {
                case "Configuración":
                    // Lógica para ir a la página de configuración
                    break;
                case "Tareas Múltiples":
                    // Navegar a la página de Tareas Múltiples
                    await Navigation.PushAsync(new TareaMultiple());
                    break;
                default:
                    // Otro caso
                    break;
            }
        }

        // Método para manejar el clic del botón "+"
        private async void HandleAddClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Page1());
        }
        private void HandleCheckedChanged(object sender, EventArgs e)
        {

        }
        private void HandleCheckTapped(object sender, EventArgs e)
        {

        }
        private void MostrarOcultarLista(object sender, EventArgs e)
        {
            listaActividadesFrame.IsVisible = !listaActividadesFrame.IsVisible;
        }
        private async void ActividadSeleccionada(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            string actividadSeleccionada = e.SelectedItem.ToString();
            await Navigation.PushAsync(new TareaDescripcion(actividadSeleccionada));

            // Deseleccionar el elemento seleccionado
            ((ListView)sender).SelectedItem = null;
        }
        private void EntryActividad_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Verifica si el texto del campo de entrada no está vacío
            if (!string.IsNullOrWhiteSpace(e.NewTextValue))
            {
                // Si el texto no está vacío, muestra el botón de envío
                btnEnviar.IsVisible = true;
            }
            else
            {
                // Si el texto está vacío, oculta el botón de envío
                btnEnviar.IsVisible = false;
            }
        }



        // Método para manejar el clic del botón de envío
        private async void HandleEnviarClicked(object sender, EventArgs e)
        {
            string actividad = entryActividad.Text;
            if (!string.IsNullOrWhiteSpace(actividad))
            {
                // Mostrar la actividad ingresada en un StackLayout con un checkbox
                var stackLayout = new StackLayout { Orientation = StackOrientation.Horizontal, Margin = new Thickness(10) };

                // Crear el checkbox
                var checkBox = new CheckBox { VerticalOptions = LayoutOptions.Center };

                // Crear el Label con el texto de la actividad
                var nuevaActividadLabel = new Label
                {
                    Text = actividad,
                    VerticalOptions = LayoutOptions.Center
                };

                // Agregar el checkbox y el Label al StackLayout
                stackLayout.Children.Add(checkBox);
                stackLayout.Children.Add(nuevaActividadLabel);

                // Agregar el evento Tapped para redirigir a TareaDescripcion
                stackLayout.GestureRecognizers.Add(new TapGestureRecognizer
                {
                    Command = new Command(async () =>
                    {
                        // Obtenemos la actividad seleccionada
                        string actividadSeleccionada = nuevaActividadLabel.Text;
                        // Maneja la navegación a la página TareaDescripcion
                        await Navigation.PushAsync(new TareaDescripcion(actividadSeleccionada));
                    })
                });

                // Agregar el StackLayout al StackLayout específico para mostrar las actividades
                actividadesStackLayout.Children.Add(stackLayout);
            }
            else
            {
                // Si no se ingresó ninguna actividad, mostrar un mensaje de error
                await DisplayAlert("Error", "Debe ingresar una actividad", "Aceptar");
            }

            // Limpia el campo de entrada después de enviar la actividad
            entryActividad.Text = string.Empty;
        }

        private void AgregarTarea(string tarea)
        {
            var stackLayout = new StackLayout { Orientation = StackOrientation.Horizontal, Margin = new Thickness(10) };

            // Crear el Label con el texto de la tarea
            var nuevaTareaLabel = new Label
            {
                Text = tarea,
                VerticalOptions = LayoutOptions.Center
            };

            // Agregar el evento de selección a la tarea
            nuevaTareaLabel.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => OnTareaSeleccionada(tarea))
            });

            // Agregar el Label al StackLayout
            stackLayout.Children.Add(nuevaTareaLabel);

            // Agregar el StackLayout al StackLayout específico para mostrar las tareas
            actividadesStackLayout.Children.Add(stackLayout);
        }
        private async void OnTareaSeleccionada(string tarea)
        {
            await Navigation.PushAsync(new TareaDescripcion(tarea));
        }

        public void AgregarTareas(string tareas)
        {
            // Tu lógica para agregar tareas aquí...
        }
    }
    }