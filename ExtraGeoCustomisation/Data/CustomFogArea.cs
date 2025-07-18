namespace ExtraGeoCustomization.Data
{
    [System.Serializable]
    public class CustomFogArea : BaseCustomisation
    {
        public eAreaType CoverageType { get; set; }
        public Vector3 Position { get; set; }
        public Vector3 Scale { get; set; }
        public string CustomMeshPath { get; set; }
        public uint FogDataID { get; set; }
    }
}
