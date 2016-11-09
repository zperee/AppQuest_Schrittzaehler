using System.Threading.Tasks;
using AppQuest_Schrittzaehler.Model;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace AppQuest_Schrittzaehler.Infrastructure
{
    public class MyScanner
    {
        public ContentPage ScanQrCode(Run run, FileSaver fileSaver, INavigation nav)
        {
            var scanPage = new ZXingScannerPage();           

            var route = new Route
            {
                Title = "Run #" + (run.RouteList.Count + 1)
            };

            scanPage.OnScanResult += async result =>
            {
                // Stop scanning
                scanPage.IsScanning = false;

                if (!string.IsNullOrEmpty(result.Text))
                {
                    var jObject = JObject.Parse(result.Text);
                    var input = jObject["input"];
                    var startStation = jObject["startStation"];
                    var arr = input as JArray;

                    route.Startstation = int.Parse(startStation.ToString());

                    if (arr == null)
                        return;

                    var firstStep = new Steps
                    {
                        Direction = "Geradeaus",
                        Step = int.Parse(arr[0].ToString())
                    };
                    route.StepList.Add(firstStep);

                    for (var index = 1; index < arr.Count; index += 2)
                    {
                        var direction = arr[index];
                        var steps = arr[index + 1];

                        var step = new Steps
                        {
                            Direction = direction.ToString(),
                            Step = int.Parse(steps.ToString())
                        };
                        route.StepList.Add(step);
                    }
                    run.RouteList.Add(route);
                    if (run.RouteList.Count > 0)
                    {                        
                        await fileSaver.SaveContentToLocalFileAsync(run.RouteList);                        
                    }
                    Device.BeginInvokeOnMainThread(() => { nav.PopModalAsync(); });
                }
            };                     
            // Navigate to our scanner page
            return scanPage;
        }
    }
}