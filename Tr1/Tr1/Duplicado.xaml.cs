using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tr1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Duplicado : TabbedPage
    {
        public Duplicado()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}