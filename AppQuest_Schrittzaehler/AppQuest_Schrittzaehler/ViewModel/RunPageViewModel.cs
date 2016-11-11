using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using AppQuest_Schrittzaehler.Annotations;
using AppQuest_Schrittzaehler.Infrastructure;
using AppQuest_Schrittzaehler.Model;
using AppQuest_Schrittzaehler.Services;
using Xamarin.Forms;

namespace AppQuest_Schrittzaehler.ViewModel
{
    public class RunPageViewModel : INotifyPropertyChanged
    {
        private readonly Route _route;
        private int _stepIndex = 0;

        private readonly IStepCounterService _stepCounterService;
        private FileSaver _fileSaver;
        private MyScanner _scanner;
        private Step _currentStep;

        public RunPageViewModel(Route route)
        {
            _scanner = new MyScanner();
            _route = route;
            _fileSaver = new FileSaver();
            _stepCounterService = DependencyService.Get<IStepCounterService>();
            
        }

        public IList<Step> StepList
        {
            get { return _route.StepList; }
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

        public ContentPage ScanButton_OnClicked()
        {
            //TODO
            //return _scanner.ScanQrCode();
            return null;
        }

        public void AddStepButton_OnClicked()
        {
            //TODO
        }


        public void OnDisappearing()
        {
            _stepCounterService.OnStep -= StepCounterServiceOnOnStep;
            _stepCounterService.Pause();
        }

        public void OnAppearing()
        {
            CurrentStep = _route.StepList[_stepIndex];
            _stepCounterService.Listen();
            _stepCounterService.OnStep += StepCounterServiceOnOnStep;
        }

        private void StepCounterServiceOnOnStep(object sender, StepEventArgs stepEventArgs)
        {            
            CurrentStep.StepsToComplete--;
            if (CurrentStep.StepsToComplete == 0 && ++_stepIndex < _route.StepList.Count)
            {
                CurrentStep = _route.StepList[_stepIndex];
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