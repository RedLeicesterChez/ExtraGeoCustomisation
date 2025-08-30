namespace ExtraGeoCustomisation.Data
{
    [System.Serializable]
    public class TerminalOverride : BaseCustomisation
    {
        public eCommandType[] OverrideCommands { get; set; }
        public string[] OverrideNames { get; set; }




    }

    [System.Serializable]
    public enum eCommandType
    {
        None = 0,
        ReactorStartup = 1,
        ReactorShutdown = 2,
        ReactorVerify = 3,
        ExtractDataCore = 4,
        UplinkConnect = 5,
        UplinkVerify = 6,
        InitTimedSequence = 7,
        VerifyTimedSequence = 8,
        
    }
}
