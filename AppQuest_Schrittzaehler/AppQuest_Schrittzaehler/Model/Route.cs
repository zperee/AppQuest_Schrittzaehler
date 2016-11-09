using System;
using System.Collections.Generic;

namespace AppQuest_Schrittzaehler.Model
{
    public class Route
    {
        public IList<Steps> StepList { get; set; } = new List<Steps>();
        public int Startstation { get; set; }
        public int Endstation { get; set; }
		public bool IsInLogbuch { get; set; }
		public string Title { get; set; }
    }
}