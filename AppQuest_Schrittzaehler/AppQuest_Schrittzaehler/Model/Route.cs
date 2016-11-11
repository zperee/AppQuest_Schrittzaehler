using System.Collections.Generic;

namespace AppQuest_Schrittzaehler.Model
{
    public class Route
    {
        public IList<Step> StepList { get; set; } = new List<Step>();
        public int Startstation { get; set; }
        public int Endstation { get; set; }
        public bool IsInLogbuch { get; set; }
        public string Title { get; set; }
    }
}