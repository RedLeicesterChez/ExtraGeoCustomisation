using ExtraGeoCustomization.Events;
using System.Text.Json.Serialization;

namespace ExtraGeoCustomization.Data
{
    [System.Serializable]
    public class BaseCustomisation
    {
        [JsonPropertyOrder(-2)]
        public eCustomisationType Type { get; set; }
        [JsonPropertyOrder(-1)]
        public bool StartEnabled { get; set; }
        [JsonPropertyOrder(0)]
        public string WorldObjectName { get; set; }

        [JsonPropertyOrder(1)]
        public int EventID { get; set; }

        [JsonPropertyOrder(2)]
        public EventData[] EventsOnActivate { get; set; }

        [JsonPropertyOrder(3)]
        public EventData[] EventsOnDeactivate { get; set; }
    }
}
