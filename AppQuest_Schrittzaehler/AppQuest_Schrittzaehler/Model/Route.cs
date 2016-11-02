using System.Collections.Generic;

namespace AppQuest_Schrittzaehler.Model
{
    public class Route
    {
        public IList<Steps> StepList { get; set; }
        public int Startstation { get; set; }
        public int Endstation { get; set; }
    }
}