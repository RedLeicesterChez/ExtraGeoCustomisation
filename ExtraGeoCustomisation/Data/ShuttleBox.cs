using ExtraGeoCustomisation.Events;
using System.Text.Json.Serialization;

namespace ExtraGeoCustomisation.Data
{
    [System.Serializable]
    public class ShuttleBox : BaseCustomisation
    {
        [JsonPropertyOrder(4)]
        public Vector3 Position { get; set; }

        [JsonPropertyOrder(5)]
        public Vector3 Rotation { get; set; }

        [JsonPropertyOrder(6)]
        public float InteractionSize { get; set; }

        [JsonPropertyOrder(7)]
        public float OnApproachTriggerSize { get; set; }

        [JsonPropertyOrder(8)]
        public BaseEventData[] EventsOnPickup { get; set; }

        [JsonPropertyOrder(9)]
        public BaseEventData[] EventsOnInsert { get; set; }

        [JsonPropertyOrder(10)]
        public BaseEventData[] EventsOnApproach { get; set; }
    }
}
