namespace ExtraGeoCustomization.Data
{
    [System.Serializable]
    public class LocalGeoData
    {
        public int geoIndex { get; set; }

        public ObjectCustomisation[] customisations { get; set; }
    }
}
