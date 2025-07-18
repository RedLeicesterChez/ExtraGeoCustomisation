namespace ExtraGeoCustomization.Data
{
    [System.Serializable]
    public class Vector4
    {
        private int v1;
        private int v2;
        private int v3;
        private int v4;

        public Vector4(int v1, int v2, int v3, int v4)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;
            this.v4 = v4;
        }

        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
        public float w { get; set; }
    }
}
