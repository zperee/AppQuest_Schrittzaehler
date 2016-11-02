using System;
using AppQuest_Schrittzaehler.Model;
using AppQuest_Schrittzaehler.ViewModel;
using Xamarin.Forms;

namespace AppQuest_Schrittzaehler.Pages
{
    public partial class RunPage : ContentPage
    {
        private readonly RunPageViewModel _runPageViewModel;
        public RunPage(Route route)
        {
            InitializeComponent();
            _runPageViewModel = new RunPageViewModel(route);
        }

        private void ScanButton_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(_runPageViewModel.ScanButton_OnClicked());
        }

        private void AddStepButton_OnClicked(object sender, EventArgs e)
        {
            _runPageViewModel.AddStepButton_OnClicked();
        }
    }
}