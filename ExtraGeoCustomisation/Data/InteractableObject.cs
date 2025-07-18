using ExtraGeoCustomization.Events;
using System.Text.Json.Serialization;

namespace ExtraGeoCustomization.Data
{
    [System.Serializable]
    public class InteractableObject : BaseCustomisation
    {
        [JsonPropertyOrder(4)]
        public Vector3 Position { get; set; }

        [JsonPropertyOrder(5)]
        public Vector3 Rotation { get; set; }

        [JsonPropertyOrder(6)]
        public float InteractionRadius { get; set; }

        [JsonPropertyOrder(7)]
        public float OnApproachTriggerSize { get; set; }

        [JsonPropertyOrder(8)]
        public string InteractableObjectPath { get; set; }

        [JsonPropertyOrder(9)]
        public EventData[] EventsOnInteract { get; set; }

        [JsonPropertyOrder(10)]
        public EventData[] EventsOnApproach { get; set; }
    }
}
