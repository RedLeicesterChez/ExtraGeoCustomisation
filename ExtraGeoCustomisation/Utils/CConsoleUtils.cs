using CConsole.Interop;
using ExtraGeoCustomisation.Utils;

namespace ExtraGeoCustomisation.Utils
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
            var RegenerateTemplateFile = new CustomCommandSetting()
            {
                Category = CConsole.Commands.CategoryType.Utility,
                Command = "Regenerate_EGC_Template_Files",
                Description = "Resets EGCs template files",
                HostOnly = false,
                MinArgumentCount = 0,
                Priority = 0,
                RequireInLevel = false,
                RequireLocalPlayer = false,
                RequireRayObject = false,
                Usage = "usage here",
            };

            CustomCommands.Register(cmdSettings, OnCommandUsed);
            CustomCommands.Register(RegenerateTemplateFile, RegenerateTemplateFileCMD);
        }

        internal static void OnCommandUsed(in CustomCmdContext ctx, string[] args)
        {
            // Code here yay
            LogEGC.Info("Called CConsole command");
        }

        internal static void RegenerateTemplateFileCMD(in CustomCmdContext ctx, string[] args)
        {
            GlobalConfig.GenerateTemplateFile = true;
            JsonHandler.LoadJson();
        }
    }
}
