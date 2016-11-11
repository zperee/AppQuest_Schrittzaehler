using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using AppQuest_Schrittzaehler.Model;
using AppQuest_Schrittzaehler.ViewModel;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace AppQuest_Schrittzaehler.Pages
{
    public partial class HomePage : ContentPage, INotifyPropertyChanged
    {
        private readonly HomePageViewModel _homePageViewModel;
        private ObservableCollection<Route> _routeList;
        private bool _noEntries = true;

        public HomePage()
        {
            InitializeComponent();
            _homePageViewModel = new HomePageViewModel();            
            RouteList = new ObservableCollection<Route>();
            BindingContext = this;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var routeList = await _homePageViewModel._fileSaver.ReadContentFromLocalFileAsync();
            var json = JsonConvert.DeserializeObject<IEnumerable<Route>>(routeList);
            if (json != null && _homePageViewModel._run.RouteList.Count == 0)
            {
                var list = new List<Route>(json);
                _homePageViewModel._run.RouteList = list;
            }

            RouteList = new ObservableCollection<Route>(_homePageViewModel._run.RouteList);

        }

        private async void AddRunButton_OnClicked(object sender, EventArgs e)
        {
            var nav = Navigation;
            await Navigation.PushModalAsync(_homePageViewModel.AddRunButton_OnClicked(nav));           
        }

        private void RouteListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = ((ListView)sender).SelectedItem;

            if (item == null) return;

            ((ListView)sender).SelectedItem = null;

            Navigation.PushAsync(_homePageViewModel.RouteListView_OnItemSelected(item));
            
        }

        public ObservableCollection<Route> RouteList
        {
            get { return _routeList; }
            set
            {
                _routeList = value;
                NoEntries = _homePageViewModel._run.RouteList.Count != 0;
                RaisePropertyChanged();
            }
        }

        public bool NoEntries
        {
            get { return _noEntries; }
            set
            {
                if (_noEntries == value) return;
                _noEntries = value;
                OnPropertyChanged();
            }
        }

        #region INotifyPropertyChanged

        public new event PropertyChangedEventHandler PropertyChanged = delegate { };

        private void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}