using Newtonsoft.Json;

namespace AppQuest_Schrittzaehler.Model
{
    public class SubmitObject
    {
        [JsonProperty("task")]
        public string Task => "Schrittzaehler";

        [JsonProperty("startStation")]
        public int StartStation { get; set; }

        [JsonProperty("endStation")]
        public int EndStation { get; set; }
    }
}