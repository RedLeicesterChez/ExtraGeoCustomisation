using ExtraGeoCustomization.Events;

namespace ExtraGeoCustomization.Data
{
    [System.Serializable]
    public class EnemySpawnpoint
    {
        public Vector3 Position { get; set; }
        public Vector3 Rotation { get; set; }

        public EventData[] EventsOnEnemySpawn { get; set; }

        public int EventID { get; set; }
    }
}
