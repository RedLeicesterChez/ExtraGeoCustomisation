using ExtraGeoCustomization.Events;

namespace ExtraGeoCustomization.Data
{
    [System.Serializable]
    public class InteractableObject
    {
        public Vector3 Position { get; set; }
        public Vector3 Rotation { get; set; }
        public float InteractionRadius { get; set; }
        public float OnApproachTriggerSize { get; set; }
        public string InteractableObjectPath { get; set; }
        public EventData[] EventsOnInteract { get; set; }
        public EventData[] EventsOnApproach { get; set; }
    }
}
