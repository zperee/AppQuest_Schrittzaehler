using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using AppQuest_Schrittzaehler.Infrastructure;
using AppQuest_Schrittzaehler.Model;
using AppQuest_Schrittzaehler.Pages;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace AppQuest_Schrittzaehler.ViewModel
{
    public class HomePageViewModel
    {
        public readonly FileSaver _fileSaver;
        public readonly Run _run;
        private readonly MyScanner _scanner;
        private ObservableCollection<Route> _data;

        public HomePageViewModel()
        {
            _scanner = new MyScanner();
            _fileSaver = new FileSaver();

            _run = new Run();
        }        

        public Page AddRunButton_OnClicked(INavigation nav)
        {            
            return _scanner.ScanQrCode(_run, _fileSaver, nav);
        }

        public ContentPage RouteListView_OnItemSelected(object sender, int index)
        {

			return new RunPage(_run, index);
        }
    }
}