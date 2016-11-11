using System.ComponentModel;
using System.Runtime.CompilerServices;
using AppQuest_Schrittzaehler.Annotations;

namespace AppQuest_Schrittzaehler.Model
{
    public class Step : INotifyPropertyChanged
    {
        private int _numberOfSteps;
        private int _stepsToComplete;
        public string Direction { get; set; }

        public int NumberOfSteps
        {
            get { return _numberOfSteps; }
            set { _numberOfSteps = value;
                StepsToComplete = value;
            }
        }

        public int StepsToComplete
        {
            get { return _stepsToComplete; }
            set
            {
                if (value == _stepsToComplete) return;
                _stepsToComplete = value;
                OnPropertyChanged();
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