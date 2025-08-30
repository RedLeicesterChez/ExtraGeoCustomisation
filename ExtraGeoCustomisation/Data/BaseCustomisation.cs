using ExtraGeoCustomisation.Events;
using System.Text.Json.Serialization;

namespace ExtraGeoCustomisation.Data
{
    [System.Serializable]
    public class BaseCustomisation
    {
        [JsonPropertyOrder(-6)]
        public eCustomisationType Type { get; set; }
        [JsonPropertyOrder(-5)]
        public bool StartEnabled { get; set; }
        [JsonPropertyOrder(-4)]
        public string WorldObjectName { get; set; }

        [JsonPropertyOrder(-3)]
        public int EventID { get; set; }

        [JsonPropertyOrder(-2)]
        public BaseEventData[] EventsOnActivate { get; set; }

        [JsonPropertyOrder(-1)]
        public BaseEventData[] EventsOnDeactivate { get; set; }
    }
}
