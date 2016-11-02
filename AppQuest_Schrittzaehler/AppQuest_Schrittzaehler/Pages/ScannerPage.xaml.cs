using AppQuest_Schrittzaehler.Model;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace AppQuest_Schrittzaehler.Pages
{
    public partial class ScannerPage : ContentPage
    {
        private readonly Route _route;

        public ScannerPage(Route route)
        {
            _route = route;
            InitializeComponent();
        }
    }
}