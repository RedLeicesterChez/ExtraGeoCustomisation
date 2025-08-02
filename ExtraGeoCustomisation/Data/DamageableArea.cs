using System.Text.Json.Serialization;

namespace ExtraGeoCustomisation.Data
{
    [System.Serializable]
    public class DamageableArea : BaseCustomisation
    {
        [JsonPropertyOrder(4)]
        public eDamageType DamageType { get; set; }

        [JsonPropertyOrder(5)]
        public float Damage { get; set; }

        [JsonPropertyOrder(6)]
        public float Infection { get; set; }

        [JsonPropertyOrder(7)]
        public eTargetType TargetType { get; set; }

        [JsonPropertyOrder(8)]
        public eAreaType AreaType { get; set; }

        [JsonPropertyOrder(9)]
        public Vector3 Scale { get; set; }

        [JsonPropertyOrder(10)]
        public Vector3 Position { get; set; }

        [JsonPropertyOrder(11)]
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
