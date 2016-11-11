using Android.Content;
using Android.Hardware;
using AppQuest_Schrittzaehler.Droid.PlattformServices;
using AppQuest_Schrittzaehler.Services;
using Java.Lang;
using Xamarin.Forms;

[assembly: Dependency(typeof(StepCounterService))]

namespace AppQuest_Schrittzaehler.Droid.PlattformServices
{
    public class StepCounterService : Object, ISensorEventListener, IStepCounterService
    {
        private static readonly int BUFFER_SIZE = 10;
        private static SensorManager _sensorManager;
        private static Sensor _rotationSensor;        


        public void OnSensorChanged(SensorEvent e)
        {
            // TODO:

            if (OnStep != null)
                OnStep(this, new StepEventArgs {Step = 1});
        }

        public void OnAccuracyChanged(Sensor sensor, SensorStatus accuracy)
        {
        }

        public event StatusUpdateHandler OnStep;

        public void Listen()
        {
            _sensorManager.RegisterListener(this, _rotationSensor, SensorDelay.Ui);
        }


        public void Pause()
        {
            _sensorManager.UnregisterListener(this);
        }

        public static void Init()
        {
            var context = Forms.Context;
            _sensorManager = (SensorManager) context.GetSystemService(Context.SensorService);
            _rotationSensor = _sensorManager.GetDefaultSensor(SensorType.RotationVector);
        }
    }
}