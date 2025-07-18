namespace ExtraGeoCustomization.Data
{
    [System.Serializable]
    public class Color
    {
        private float v1;
        private float v2;
        private float v3;
        private float v4;

        public Color(float v1, float v2, float v3, float v4)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;
            this.v4 = v4;
        }

        public float r { get; set; }
        public float g { get; set; }
        public float b { get; set; }
        public float a { get; set; }
    }
}
