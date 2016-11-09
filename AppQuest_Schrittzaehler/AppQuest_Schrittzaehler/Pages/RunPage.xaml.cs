using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using AppQuest_Schrittzaehler.Model;
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
			_route = route;
        }

        private void ScanButton_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(_runPageViewModel.ScanButton_OnClicked());
        }

        private void AddStepButton_OnClicked(object sender, EventArgs e)
        {
            _runPageViewModel.AddStepButton_OnClicked();
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