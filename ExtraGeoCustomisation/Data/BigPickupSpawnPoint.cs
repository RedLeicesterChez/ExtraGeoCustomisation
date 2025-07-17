namespace ExtraGeoCustomization.Data
{
    [System.Serializable]
    public class BigPickupSpawnPoint
    {
        public Vector3 position { get; set; }
        public Vector3 rotation { get; set; }
        public bool ForceSpawn { get; set; }
        public uint ItemID { get; set; }
    }
}
