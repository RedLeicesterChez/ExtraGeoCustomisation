using ExtraGeoCustomization.Events;
using System.Text.Json.Serialization;

namespace ExtraGeoCustomization.Data
{
    [System.Serializable]
    public class CustomTriggerBox : BaseCustomisation
    {
        [JsonPropertyOrder(4)]
        public eAreaType CoverageType { get; set; }

        [JsonPropertyOrder(5)]
        public Vector3 Position { get; set; }

        [JsonPropertyOrder(6)]
        public Vector3 Rotation { get; set; }

        [JsonPropertyOrder(7)]
        public Vector3 Vector3 { get; set; }

        [JsonPropertyOrder(8)]
        public BaseEventData[] EventsOnEnter { get; set; }

        [JsonPropertyOrder(9)]
        public BaseEventData[] EventsOnExit { get; set; }

        [JsonPropertyOrder(10)]
        public BaseEventData[] EventsOnLookat { get; set; }
    }
}
