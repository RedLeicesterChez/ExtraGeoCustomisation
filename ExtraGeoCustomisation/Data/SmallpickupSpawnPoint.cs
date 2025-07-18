namespace ExtraGeoCustomization.Data
{
    [System.Serializable]
    public class SmallPickupSpawnPoint : BaseCustomisation
    {
        public Vector3 Position { get; set; }
        public Vector3 Rotation { get; set; }
        public bool ForceSpawn { get; set; }
        public uint ItemID { get; set; }
    }
}
