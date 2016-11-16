using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using AppQuest_Schrittzaehler.Model;
using AppQuest_Schrittzaehler.Services;
using AppQuest_Schrittzaehler.ViewModel;
using Xamarin.Forms;

namespace AppQuest_Schrittzaehler.Pages
{
    public partial class RunPage : ContentPage, INotifyPropertyChanged
    {
        private readonly RunPageViewModel _runPageViewModel;


        private ObservableCollection<Route> _routeList;
        private Route _route;

        public RunPage(Route route)
        {
            InitializeComponent();
            _runPageViewModel = new RunPageViewModel(route);
            BindingContext = _runPageViewModel;
            _route = route;
        }

        private void AddStepButton_OnClicked(object sender, EventArgs e)
        {
            _runPageViewModel.AddStepButton_OnClicked();
        }

		private async void FinishScanButton_OnClicked(object sender, EventArgs e)
		{
			var nav = Navigation;
			await Navigation.PushModalAsync(_runPageViewModel.FinishScanButton_OnClicked(nav));
		}

		private void SendToLogBuch_OnClicked(object sender, EventArgs e)
		{
			_runPageViewModel.SendToLogBuch();
		}

		protected override void OnAppearing()
        {
            base.OnAppearing();         
            _runPageViewModel.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            _runPageViewModel.OnDisappearing();
        }

		public ObservableCollection<Route> RouteList
		{
			get { return _routeList; }
			set
			{
				_routeList = value;
				RaisePropertyChanged();
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