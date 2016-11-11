using Android.Content;
using Android.Hardware;
using AppQuest_Schrittzaehler.Droid.PlattformServices;
using AppQuest_Schrittzaehler.Infrastructure;
using AppQuest_Schrittzaehler.Services;
using Java.Lang;
using Xamarin.Forms;

[assembly: Dependency(typeof(StepCounterService))]

namespace AppQuest_Schrittzaehler.Droid.PlattformServices
{
    public class StepCounterService : Object, ISensorEventListener, IStepCounterService
    {
        private const int Long = 1000;
        private const int Short = 50;
        private static SensorManager _sensorManager;
        private static Sensor _rotationSensor;
        private bool _accelerating;
        private readonly RingBuffer _longBuffer = new RingBuffer(Long);
        private readonly RingBuffer _shortBuffer = new RingBuffer(Short);

        public void OnSensorChanged(SensorEvent e)
        {
            var x = e.Values[0];
            var y = e.Values[1];
            var z = e.Values[2];

            var magnitude = (float) (Math.Pow(x, 2) + Math.Pow(y, 2) + Math.Pow(z, 2));

            _shortBuffer.Put(magnitude);
            _longBuffer.Put(magnitude);

            var shortAverage = _shortBuffer.GetAverage();
            var longAverage = _longBuffer.GetAverage();

            if (!_accelerating && (shortAverage > longAverage*1.1))
            {
                _accelerating = true;

                if (OnStep != null)
                    OnStep(this, new StepEventArgs {Step = 1});
            }

            if (_accelerating && (shortAverage < longAverage*0.9))
            {
                _accelerating = false;
            }
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