using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AppQuest_Schrittzaehler.Model;
using Newtonsoft.Json;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace AppQuest_Schrittzaehler.Infrastructure
{
	public class MyScanner
	{
		public ContentPage ScanQrCode(Run run)
		{
			var scanPage = new ZXingScannerPage();

			scanPage.OnScanResult += (result) =>
			{
				// Stop scanning
				scanPage.IsScanning = false;

			    if (!string.IsNullOrEmpty(result.Text))
			    {
			        var json = JsonConvert.DeserializeObject<IEnumerable<ReceiveObject>>(result.Text);
			        var list = json.ToList();                   

			        var test = result.Text;

			        var route = new Route
			        {
                       Title = "Run #" + (run.RouteList.Count + 1),                       
                    };

                    


                }
			    else
			    {
			        //await DisplayAlert("Warnung", "QR-Code konnte nicht gescannt werden.", "OK");

			        // Pop the page and show the result
			        //Device.BeginInvokeOnMainThread(() => { Navigation.PopModalAsync(); });
			    }
			};

			// Navigate to our scanner page
			return scanPage;
		}
	}
}
