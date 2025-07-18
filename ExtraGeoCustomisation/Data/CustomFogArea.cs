using System.Text.Json.Serialization;

namespace ExtraGeoCustomization.Data
{
    [System.Serializable]
    public class CustomFogArea : BaseCustomisation
    {
        [JsonPropertyOrder(4)]
        public eAreaType CoverageType { get; set; }

        [JsonPropertyOrder(5)]
        public Vector3 Position { get; set; }

        [JsonPropertyOrder(6)]
        public Vector3 Scale { get; set; }

        [JsonPropertyOrder(7)]
        public string CustomMeshPath { get; set; }

        [JsonPropertyOrder(8)]
        public uint FogDataID { get; set; }
    }
}
