using ExtraGeoCustomization.Events;
using System.Text.Json.Serialization;

namespace ExtraGeoCustomization.Data
{
    [System.Serializable]
    public class CustomGenerator : BaseCustomisation
    {
        [JsonPropertyOrder(4)]
        public Vector3 Position { get; set; }

        [JsonPropertyOrder(5)]
        public Vector3 Rotation { get; set; }

        [JsonPropertyOrder(6)]
        public bool BiDirectional { get; set; }

        [JsonPropertyOrder(7)]
        public bool StartEmpty { get; set; }

        [JsonPropertyOrder(8)]
        public uint ItemDataID { get; set; }

        [JsonPropertyOrder(9)]
        public EventData[] EventsOnInsert { get; set; }

        [JsonPropertyOrder(10)]
        public EventData[] EventsOnRemove { get; set; }

        [JsonIgnore]
        public bool StartEnabled;
    }
}
