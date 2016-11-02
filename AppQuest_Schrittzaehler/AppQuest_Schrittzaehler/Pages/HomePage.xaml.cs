using System;
using AppQuest_Schrittzaehler.ViewModel;
using Xamarin.Forms;

namespace AppQuest_Schrittzaehler.Pages
{
    public partial class HomePage : ContentPage
    {
        private readonly HomePageViewModel _homePageViewModel;

        public HomePage()
        {
            InitializeComponent();
            _homePageViewModel = new HomePageViewModel();
        }

        private void AddRunButton_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(_homePageViewModel.AddRunButton_OnClicked());
        }

        private void RouteListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            _homePageViewModel.RoutListView_OnItemSelected(sender);
        }
    }
}