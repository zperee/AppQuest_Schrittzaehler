using System;
using AppQuest_Schrittzaehler.Infrastructure;
using AppQuest_Schrittzaehler.Model;
using AppQuest_Schrittzaehler.Services;
using Xamarin.Forms;

namespace AppQuest_Schrittzaehler.ViewModel
{
	public class RunPageViewModel
	{
		MyScanner _scanner;
		Route _route; 
		FileSaver _fileSaver;

	    private readonly IStepCounterService _stepCounterService;

		public RunPageViewModel(Route route) {
			_scanner = new MyScanner();
			_route = route; 
			_fileSaver = new FileSaver();
		    _stepCounterService = DependencyService.Get<IStepCounterService>();
		}

		public ContentPage ScanButton_OnClicked()
		{
			 //return _scanner.ScanQrCode();
		    return null;
		}

		public void AddStepButton_OnClicked(){
			
		}


	    public void OnDisappearing()
	    {
            _stepCounterService.OnStep -= StepCounterServiceOnOnStep;
            _stepCounterService.Pause();
        }

	    public void OnAppearing()
	    {
            _stepCounterService.Listen();
            _stepCounterService.OnStep += StepCounterServiceOnOnStep;
        }

	    public void DisplaySteps(Label directionLabel, Label stepLabel)
	    {
            if (_route != null)
	        {
	            foreach (var step in _route.StepList)
	            {
	                directionLabel.Text = step.Direction;
	                stepLabel.Text = step.Step.ToString();
	            }
	        }
	        else
	        {
	            return;
	        }
	    }

	    private void StepCounterServiceOnOnStep(object sender, StepEventArgs stepEventArgs)
	    {
	        
	    }
	}
}
