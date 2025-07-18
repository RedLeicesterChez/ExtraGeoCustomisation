namespace ExtraGeoCustomization.Data
{
    [System.Serializable]
    public class Vector3
    {
        public Vector3(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }
}
