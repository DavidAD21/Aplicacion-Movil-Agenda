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
	public partial class TareaDescripcion : ContentPage
	{
        private string nombreTarea;

        public TareaDescripcion(string nombreTarea)
        {
            InitializeComponent();
            this.nombreTarea = nombreTarea;
           
        }

    }
}