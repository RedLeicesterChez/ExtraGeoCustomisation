using ExtraGeoCustomisation.Events;

namespace ExtraGeoCustomisation.Data
{
    [System.Serializable]
    public class DeLinkedChainedPuzzle : BaseCustomisation
    {
        public uint ChainedPuzzleID { get; set; }
        public bool PlayAlarmAudio { get; set; }
        public BaseEventData[] EventsOnScanFinish { get; set; }
        public BaseEventData[] EventsOnScanActivate { get; set; }
    }
}
