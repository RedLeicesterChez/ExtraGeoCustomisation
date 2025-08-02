using ExtraGeoCustomisation.Events;

namespace ExtraGeoCustomisation.Data
{
    //Needs to be fleshed out more but I'm tired will do at a later date
    [System.Serializable]
    public class TileEnemy : BaseCustomisation
    {
        public uint EnemyDataID { get; set; }
        public bool StartAsleep { get; set; }
        public PhaseData[] Phases { get; set; }
        public BaseEventData[] EventsOnWakeup { get; set; }
        public BaseEventData[] EventsOnKill { get; set; }
    }

    [System.Serializable]
    public class PhaseData
    {
        public int DamageUntilProgress { get; set; }
        public RemoteWeakspot[] RemoteWeakspots { get; set; }
        public BaseEventData[] EventsOnEnterPhase { get; set; }
        public BaseEventData[] EventsOnExitPhase { get; set; }
    }

    [System.Serializable]
    public class RemoteWeakspot
    {
        public float Health { get; set; }
        public float ArmourValue { get; set; }
    }
}
