using ExtraGeoCustomization.Events;

namespace ExtraGeoCustomization.Data
{
    [System.Serializable]
    public class CustomGenerator
    {
        public Vector3 Vector3 { get; set; }
        public Vector3 Rotation { get; set; }
        public bool BiDirectional { get; set; }
        public bool StartEmpty { get; set; }
        public uint ItemDataID { get; set; }
        public int EventID { get; set; }

        public EventData[] EventsOnInsert { get; set; }
        public EventData[] EventsOnRemove { get; set; }
    }
}
