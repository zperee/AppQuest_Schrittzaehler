using System;
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

        private async void ScanButton_OnClicked(object sender, EventArgs e)
        {
            var scanPage = new ZXingScannerPage();

            scanPage.OnScanResult += result =>
            {
                // Stop scanning
                scanPage.IsScanning = false;

                //TODO Add Scanned Element to List

                // Pop the page and show the result
                Device.BeginInvokeOnMainThread(() => { Navigation.PopModalAsync(); });
            };

            // Navigate to our scanner page
            await Navigation.PushModalAsync(scanPage);
        }
    }
}