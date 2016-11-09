using System;
using System.Collections.ObjectModel;
using AppQuest_Schrittzaehler.Model;
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
            RouteListView.ItemsSource = _homePageViewModel._run.RouteList;
        }

        private async void AddRunButton_OnClicked(object sender, EventArgs e)
        {
            var nav = Navigation;
            await Navigation.PushModalAsync(await _homePageViewModel.AddRunButton_OnClicked(nav));           
        }

        private void RouteListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            _homePageViewModel.RoutListView_OnItemSelected(sender);
        }
    }
}