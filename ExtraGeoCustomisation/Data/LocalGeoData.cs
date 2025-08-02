namespace ExtraGeoCustomisation.Data
{
    [System.Serializable]
    public class LocalGeoData
    {
        public int geoIndex { get; set; }
        public BaseCustomisation[] Customisations { get; set; }
    }
}
