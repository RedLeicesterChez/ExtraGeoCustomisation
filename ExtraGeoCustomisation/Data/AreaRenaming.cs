namespace ExtraGeoCustomization.Data
{
    [System.Serializable]
    public class AreaRenaming : BaseCustomisation
    {
        public string RenamedText { get; set; }
        public int[] AreaIndexes { get; set; }
        public bool SeparateTerminalPings { get; set; }
    }
}
