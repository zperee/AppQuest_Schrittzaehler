using System;
using Android.Hardware;

namespace AppQuest_Memory.Droid.PlattformServices
{
	public class StepCounter : Java.Lang.Object, ISensorEventListener
	{

		private static readonly int LONG = 1000;
		private static readonly int SHORT = 50;

		private bool accelerating = false;
		private StepListener Listener;

		private RingBuffer shortBuffer = new RingBuffer(SHORT);
		private RingBuffer longBuffer = new RingBuffer(LONG);

		public StepCounter(StepListener listener)
		{
			this.Listener = listener;
		}

		public void OnAccuracyChanged(Sensor sensor, SensorStatus accuracy)
		{
		}

		public void OnSensorChanged(SensorEvent e) {

			float x = e.Values [0];
		float y = e.Values [1];
		float z = e.Values [2];
		float magnitude = (float)(Math.Pow(x, 2) + Math.Pow(y, 2) + Math.Pow(z, 2));

		shortBuffer.Put(magnitude);
		longBuffer.Put(magnitude);

		float shortAverage = shortBuffer.GetAverage();
		float longAverage = longBuffer.GetAverage();

		if (!accelerating && (shortAverage > longAverage* 1.1)) {
			accelerating = true;
			Listener.OnStep();
		}

		if ((accelerating && shortAverage<longAverage* 0.9)) {
			accelerating = false;
		}
	}
}
}