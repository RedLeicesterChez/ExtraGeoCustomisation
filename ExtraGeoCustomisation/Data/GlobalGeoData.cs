namespace ExtraGeoCustomization.Data
{
    [System.Serializable]
    public class GlobalGeoData
    {
        //I'm not 100% sure if this is a viable feature
        public string GeoPath { get; set; }

        public BaseCustomisation[] customisations { get; set; }
    }
}
