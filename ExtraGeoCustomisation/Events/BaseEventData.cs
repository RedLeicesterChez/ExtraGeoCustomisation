namespace ExtraGeoCustomisation.Events
{
    [System.Serializable]
    public class BaseEventData
    {
        public eEGCEventType Type { get; set; }
        public int EventID { get; set; }
        public bool Enable { get; set; }

        public enum eEGCEventType
        {
            none = 0,
            TextObject = 1,
            DamageBox = 2,
            ShuttleBox = 3,
            PhysicsObject = 4,
            InteractableObject = 5,
            EnemySpawnpoint = 6,
            FogArea = 7,
            TriggerBox = 8,
            CustomGenerator = 9,
            TileEnemy = 10,
        }
    }
}
