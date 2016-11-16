﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Acr.UserDialogs;
using AppQuest_Schrittzaehler.Annotations;
using AppQuest_Schrittzaehler.Infrastructure;
using AppQuest_Schrittzaehler.Model;
using AppQuest_Schrittzaehler.Services;
using Xamarin.Forms;

namespace AppQuest_Schrittzaehler.ViewModel
{
	public class RunPageViewModel : INotifyPropertyChanged
	{
		private readonly int _index;
		private Run _run;
		private int _stepIndex = 0;

		private readonly IStepCounterService _stepCounterService;
		private FileSaver _fileSaver;
		private MyScanner _scanner;
		private Step _currentStep;

		public RunPageViewModel(Run run, int index)
		{
			_scanner = new MyScanner();
			_index = index;
			_run = run;
			_fileSaver = new FileSaver();
			_stepCounterService = DependencyService.Get<IStepCounterService>();
			CurrentStep = run.RouteList[index].StepList[_stepIndex];

		}

		public IList<Step> StepList
		{
			get { return _run.RouteList[_index].StepList; }
		}

		public Step CurrentStep
		{
			get { return _currentStep; }
			set
			{
				if (Equals(value, _currentStep)) return;
				_currentStep = value;
				OnPropertyChanged();
			}
		}

		public ContentPage FinishScanButton_OnClicked(INavigation nav)
		{
			return _scanner.ScanQrCode(_fileSaver, nav, _run, _index);
		}

		public async void AddStepButton_OnClicked()
		{

			if (CurrentStep.StepsToComplete == 1 && ++_stepIndex < _run.RouteList[_index].StepList.Count)
			{
				CurrentStep.StepsToComplete--;
				CurrentStep = _run.RouteList[_index].StepList[_stepIndex];
			}
			else if (CurrentStep.StepsToComplete > 1)
			{
				CurrentStep.StepsToComplete--;
			}
			else if (CurrentStep.StepsToComplete == 1)
			{
				CurrentStep.StepsToComplete--;
				await Application.Current.MainPage.DisplayAlert("Info", "Alle Schritte auf dieser Route wurden abgelaufen!", "OK");
			}
			else {
				await Application.Current.MainPage.DisplayAlert("Info", "Alle Schritte auf dieser Route wurden abgelaufen!", "OK");
			}
		}

		public void SendToLogBuch()
		{
			var logBuch = DependencyService.Get<ILogBuchService>();
			_run.RouteList[_index].IsInLogbuch = true;
			logBuch.OpenLogBuch("Schrittzaehler", _run.RouteList[_index].Startstation.ToString(), _run.RouteList[_index].Endstation.ToString());
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

		private void StepCounterServiceOnOnStep(object sender, StepEventArgs stepEventArgs)
		{
			CurrentStep.StepsToComplete--;
			if (CurrentStep.StepsToComplete == 0 && ++_stepIndex < _run.RouteList[_index].StepList.Count)
			{
				CurrentStep = _run.RouteList[_index].StepList[_stepIndex];
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		[NotifyPropertyChangedInvocator]
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}