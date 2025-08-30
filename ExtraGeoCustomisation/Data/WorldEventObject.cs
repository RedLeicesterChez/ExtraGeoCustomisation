using ExtraGeoCustomisation.Events;
using System.Text.Json.Serialization;

namespace ExtraGeoCustomisation.Data
{
    [System.Serializable]
    public class WorldEventObject : BaseCustomisation
    {
        public Vector3 Position { get; set; }
        public Vector3 Rotation { get; set; }

        [JsonIgnore]
        public new bool StartEnabled;

        [JsonIgnore]
        public new int EventID;

        [JsonIgnore]
        public new BaseEventData[] EventsOnActivate;

        [JsonIgnore]
        public new BaseEventData[] EventsOnDeactivate;
    }
}
