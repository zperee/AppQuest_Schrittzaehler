using AppQuest_Schrittzaehler.Infrastructure;
using AppQuest_Schrittzaehler.Model;
using Xamarin.Forms;

namespace AppQuest_Schrittzaehler.ViewModel
{
	public class RunPageViewModel
	{
		MyScanner _scanner;
		Route _route; 
		FileSaver _fileSaver;

		public RunPageViewModel(Route route) {
			_scanner = new MyScanner();
			_route = route; 
			_fileSaver = new FileSaver();
		}

		public ContentPage ScanButton_OnClicked()
		{
			 //return _scanner.ScanQrCode();
		    return null;
		}

		public void AddStepButton_OnClicked(){
			
		}


	}
}
