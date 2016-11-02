using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppQuest_Schrittzaehler.ViewModel
{
	public class HomePageViewModel
	{
		MyScanner _scanner;
		Run _run; 

		public HomePageViewModel() {
			_scanner = new MyScanner();

			//TODO Fill from File
			_run = new Run();
		}

		public ContentPage AddRunButton_OnClicked()
		{
			 return _scanner.ScanQrCode();
		}

		public ContentPage RoutListView_OnItemSelected(object sender){
			return new RunPage();
		}
	}
}

