using System.Linq;

namespace AppQuest_Schrittzaehler.Infrastructure
{
    public class RingBuffer
    {
        private readonly float[] _buffer;
        public int Capacity;
        public int Current = 0;
        public int Count = 0;

        public int GetCount()
        {
            return Count;
        }

        public RingBuffer(int capacity)
        {
            Capacity = capacity;
            _buffer = new float[capacity];
        }

        public void Put(float f)
        {
            _buffer[Current] = f;
            Current++;
            Count++;
            Current = Current % Capacity;
        }

        public float GetAverage()
        {
            float avg = 0;

            foreach (float f in _buffer)
            {
                avg += f;
            }

            if (Count > Capacity)
            {
                return avg / Capacity;
            }
            return avg / Count;
        }
    }
}