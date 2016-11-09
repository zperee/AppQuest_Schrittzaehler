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
        private readonly FileSaver _fileSaver;
        public readonly Run _run;
        private readonly MyScanner _scanner;
        private ObservableCollection<Route> _data;

        public HomePageViewModel()
        {
            _scanner = new MyScanner();
            _fileSaver = new FileSaver();

            //TODO Fill from File
            _run = new Run();
        }

        public async Task<Page> AddRunButton_OnClicked(INavigation nav)
        {
            var routeList = await _fileSaver.ReadContentFromLocalFileAsync();
            var json = JsonConvert.DeserializeObject<IEnumerable<Route>>(routeList);
            if (json != null && _run.RouteList.Count == 0)
            {
                var list = new List<Route>(json);
                _run.RouteList = list;
            }
            return _scanner.ScanQrCode(_run, _fileSaver, nav);
        }

        public ContentPage RoutListView_OnItemSelected(object sender)
        {
            var item = (Route) sender;
            return new RunPage(item);
        }
    }
}