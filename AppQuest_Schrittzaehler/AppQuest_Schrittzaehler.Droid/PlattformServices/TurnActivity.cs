using System;
using Android.OS;
using Android.Hardware;
using Android.App;
using Android.Widget;

namespace AppQuest_Memory.Droid.PlattformServices
{
	public class TurnActivity : Activity, ISensorEventListener
	{

		private static readonly int BUFFER_SIZE = 10;
		private SensorManager sensorManager;
		private RingBuffer initialRotation = new RingBuffer(BUFFER_SIZE);
		private RingBuffer rotation = new RingBuffer(BUFFER_SIZE);
		private Sensor rotationSensor;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			//SetContentView(R.layout.activity_walk);
			sensorManager = (SensorManager)GetSystemService(SensorService);
			rotationSensor = sensorManager.GetDefaultSensor(SensorType.RotationVector);
		}

		protected override void OnResume()
		{
			base.OnResume();
			sensorManager.RegisterListener(this, rotationSensor, SensorDelay.Ui);
		}

		protected override void OnPause()
		{
			base.OnPause();
			sensorManager.UnregisterListener(this);
		}

		float[] rotationMatrix = new float[16];
		float[] orientationVals = new float[3];


		public void OnSensorChanged(SensorEvent e)
		{
			//if (e.Sensor.GetType() == SensorType.RotationVector)
				/*if (e.Sensor.GetType() == Sensor.StringTypeRotationVector);*/
			/*{
				SensorManager.GetRotationMatrixFromVector(rotationMatrix, (float[])e.Values);
				SensorManager.GetOrientation(rotationMatrix, orientationVals);

				orientationVals[0] = (float)Java.Lang.Math.ToDegrees(orientationVals[0]);

				// Zuerst füllen wir den Buffer mit der Initialrotation um den
				// Startwinkel zu bestimmen, und wenn dieser voll ist (was sehr
				// schnell passiert), dann füllen wir einen zweiten RingBuffer.
				if (initialRotation.getCount() < BUFFER_SIZE)
				{
					initialRotation.Put(orientationVals[0]);
				}
				else {
					rotation.Put(orientationVals[0]);
				}

				// Wenn der zweite Buffer auch gefüllt ist, vergleichen wir die
				// beiden Durchschnittswerte fortlaufend, und sobald wir eine
				// Drehung von grösser als 50 Grad erkennen, melden wir dies.
				if (rotation.getCount() >= BUFFER_SIZE)
				{
					float r = Math.Abs(rotation.GetAverage() - initialRotation.GetAverage());
					if (r > 50)
					{
						Toast.MakeText(this, "Du hast dich gedreht!", ToastLength.Long).Show();
					}
				}
			}*/
		}

		public void OnAccuracyChanged(Sensor sensor, SensorStatus accuracy)
		{
		}

	}
}
