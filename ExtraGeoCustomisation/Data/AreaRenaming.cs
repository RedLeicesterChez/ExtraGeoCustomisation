using System.Text.Json.Serialization;

namespace ExtraGeoCustomisation.Data
{
    [System.Serializable]
    public class AreaRenaming : BaseCustomisation
    {
        [JsonPropertyOrder(4)]
        public string RenamedText { get; set; }

        [JsonPropertyOrder(5)]
        public int[] AreaIndexes { get; set; }

        [JsonPropertyOrder(6)]
        public bool SeparateTerminalPings { get; set; }

        [JsonIgnore]
        public bool StartEnabled;
    }
}
