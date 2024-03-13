using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tr1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TareaMultiple : ContentPage
    {
        public TareaMultiple()
        {
            InitializeComponent();
        }

        private void Editor_Focused(object sender, FocusEventArgs e)
        {
            if (editorTareas.Text == "Tarea 1\nTarea 2\nTarea 3\netc." && e.IsFocused)
            {
                editorTareas.Text = string.Empty;
            }
            else
            {
                editorTareas.TextColor = Color.Black;
            }
        }

        private async void GuardarTareas_Tapped(object sender, EventArgs e)
        {
            string tareas = editorTareas.Text;

            // Aquí deberías implementar la lógica para guardar las tareas en algún lugar, como una base de datos o en la memoria de la aplicación
            // Por ejemplo, puedes usar una clase de base de datos o un servicio de almacenamiento

            // En este ejemplo, simplemente pasaremos las tareas a la página principal y cerraremos esta página
            var mainPage = Navigation.NavigationStack.FirstOrDefault(p => p is MainPage) as MainPage;
            if (mainPage != null)
            {
                mainPage.AgregarTareas(tareas); // Método personalizado en la página principal para agregar las tareas
            }
            await Navigation.PopAsync(); // Cerramos la página de TareaMultiple y volvemos a la página principal
        }

    }
}