using System.Text.Json.Serialization;

namespace ExtraGeoCustomisation.Data
{
    [System.Serializable]
    public class BigPickupSpawnPoint : BaseCustomisation
    {
        [JsonPropertyOrder(4)]
        public Vector3 position { get; set; }

        [JsonPropertyOrder(5)]
        public Vector3 rotation { get; set; }

        [JsonPropertyOrder(6)]
        public bool ForceSpawn { get; set; }

        [JsonPropertyOrder(7)]
        public uint ItemID { get; set; }

        [JsonIgnore]
        public bool StartEnabled;
    }
}
