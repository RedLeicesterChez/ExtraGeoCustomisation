using ExtraGeoCustomization.Events;

namespace ExtraGeoCustomization.Data
{
    public class BaseCustomisation
    {
        public eCustomisationType Type { get; set; }
        public int EventID { get; set; }
        public EventData[] EventsOnActivate { get; set; }
        public EventData[] EventsOnDeactivate { get; set; }
    }
}
