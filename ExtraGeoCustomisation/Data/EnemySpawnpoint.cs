using ExtraGeoCustomization.Events;
using System.Text.Json.Serialization;

namespace ExtraGeoCustomization.Data
{
    [System.Serializable]
    public class EnemySpawnpoint : BaseCustomisation
    {
        [JsonPropertyOrder(4)]
        public Vector3 Position { get; set; }

        [JsonPropertyOrder(5)]
        public Vector3 Rotation { get; set; }

        [JsonPropertyOrder(6)]
        public EventData[] EventsOnEnemySpawn { get; set; }
    }
}
