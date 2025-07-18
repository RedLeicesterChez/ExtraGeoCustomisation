using ExtraGeoCustomization.Events;

namespace ExtraGeoCustomization.Data
{
    [System.Serializable]
    public class CustomTriggerBox : BaseCustomisation
    {
        public eAreaType CoverageType { get; set; }
        public Vector3 Position { get; set; }
        public Vector3 Rotation { get; set; }
        public Vector3 Vector3 { get; set; }
        
        public EventData[] EventsOnEnter { get; set; }
        public EventData[] EventsOnExit { get; set; }
        public EventData[] EventsOnLookat { get; set; }
    }
}
