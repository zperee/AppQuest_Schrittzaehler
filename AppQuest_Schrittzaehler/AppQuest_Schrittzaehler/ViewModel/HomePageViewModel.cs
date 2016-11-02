using AppQuest_Schrittzaehler.Infrastructure;
using AppQuest_Schrittzaehler.Model;
using AppQuest_Schrittzaehler.Pages;
using Xamarin.Forms;

namespace AppQuest_Schrittzaehler.ViewModel
{
    public class HomePageViewModel
    {
        private Run _run;
        private readonly MyScanner _scanner;

        public HomePageViewModel()
        {
            _scanner = new MyScanner();

            //TODO Fill from File
            _run = new Run();
        }

        public ContentPage AddRunButton_OnClicked()
        {
            return _scanner.ScanQrCode();
        }

        public ContentPage RoutListView_OnItemSelected(object sender)
        {
            var item = (Route) sender;
            return new RunPage(item);
        }
    }
}