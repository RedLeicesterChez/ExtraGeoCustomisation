namespace ExtraGeoCustomization.Data
{
    [System.Serializable]
    public class DamageableArea : BaseCustomisation
    {
        public eDamageType DamageType { get; set; }
        public float Damage { get; set; }
        public float Infection { get; set; }
        public eTargetType TargetType { get; set; }

        public eAreaType AreaType { get; set; }
        public Vector3 Scale { get; set; }
        public Vector3 Position { get; set; }
        public string CustomMeshPath { get; set; }
    }

    [System.Serializable]
    public enum eDamageType
    {
        Health = 0,
        Infection = 1,
        Both = 2,
    }

    [System.Serializable]
    public enum eTargetType
    {
        Players = 0,
        Enemies = 1,
        Both = 2,
    }
}
