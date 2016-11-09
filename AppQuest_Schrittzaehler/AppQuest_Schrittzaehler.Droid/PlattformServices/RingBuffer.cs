using System.Collections.Generic;

namespace AppQuest_Memory.Droid.PlattformServices
{
	class RingBuffer
	{
		List<float> buffer;
		int capacity;
		int current = 0;
		int count = 0;

		public int getCount()
		{
			return count;
		}

		public RingBuffer(int capacity)
		{
			this.capacity = capacity;
			//buffer = new float[capacity];
		}

		public void Put(float f)
		{
			buffer[current] = f;
			current++;
			count++;
			current = current % capacity;
		}

		public float GetAverage()
		{
			float avg = 0;
			foreach (var f in buffer)
			{
				avg += f;
			}

			if (count > capacity)
			{
				return avg / capacity;
			}
			else {
				return avg / count;
			}
		}
	}
}