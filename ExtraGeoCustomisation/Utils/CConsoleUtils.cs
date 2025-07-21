using CConsole.Interop;
using ExtraGeoCustomisation.Utils;

namespace ExtraGeoCustomization.Utils
{
    public static class CConsoleUtils
    {
        public static void RegisterCommands()
        {
            var cmdSettings = new CustomCommandSetting()
            {
                Category = CConsole.Commands.CategoryType.Utility,
                Command = "ReloadEGCData",
                Description = "Reloads ExtraGeoCustomisation data and updates the current level (if applicable)",
                HostOnly = true,
                MinArgumentCount = 0,
                Priority = 0,
                RequireInLevel = false,
                RequireLocalPlayer = false,
                RequireRayObject = false,
                Usage = "usage here",
            };

            CustomCommands.Register(cmdSettings, OnCommandUsed);
        }

        internal static void OnCommandUsed(in CustomCmdContext ctx, string[] args)
        {
            // Code here yay
            LogEGC.Info("Called CConsole command");
        }
    }
}
