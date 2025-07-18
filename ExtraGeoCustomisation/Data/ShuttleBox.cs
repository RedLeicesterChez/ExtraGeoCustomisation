using ExtraGeoCustomization.Events;

namespace ExtraGeoCustomization.Data
{
    [System.Serializable]
    public class ShuttleBox : BaseCustomisation
    {
        public Vector3 Position { get; set; }
        public Vector3 Rotation { get; set; }
        public float InteractionSize { get; set; }
        public float OnApproachTriggerSize { get; set; }

        public EventData[] EventsOnPickup { get; set; }
        public EventData[] EventsOnInsert { get; set; }
        public EventData[] EventsOnApproach { get; set; }
    }
}
