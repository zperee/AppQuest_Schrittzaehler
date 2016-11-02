using System;
using AppQuest_Schrittzaehler.ViewModel;
using Xamarin.Forms;

namespace AppQuest_Schrittzaehler.Pages
{
    public partial class HomePage : ContentPage
    {
        private HomePageViewModel _homePageViewModel;
        public HomePage()
        {
            InitializeComponent();
            _homePageViewModel = new HomePageViewModel();

        }

        private void StartStationScanButton_OnClicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void EndStationScanButton_OnClicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}