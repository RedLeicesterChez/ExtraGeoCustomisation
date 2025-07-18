using ExtraGeoCustomization.Events;

namespace ExtraGeoCustomization.Data
{
    //Needs to be fleshed out more but I'm tired will do at a later date
    [System.Serializable]
    public class TileEnemy : BaseCustomisation
    {
        public uint EnemyDataID { get; set; }
        public bool StartAsleep { get; set; }
        public PhaseData[] Phases { get; set; }
        public EventData[] EventsOnWakeup { get; set; }
        public EventData[] EventsOnKill { get; set; }
    }

    [System.Serializable]
    public class PhaseData
    {
        public int DamageUntilProgress { get; set; }
        public RemoteWeakspot[] RemoteWeakspots { get; set; }
        public EventData[] EventsOnEnterPhase { get; set; }
        public EventData[] EventsOnExitPhase { get; set; }
    }

    [System.Serializable]
    public class RemoteWeakspot
    {
        public float Health { get; set; }
        public float ArmourValue { get; set; }
    }
}
