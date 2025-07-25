﻿using BepInEx.Core.Logging.Interpolation;
using BepInEx.Logging;
using System.Diagnostics;

namespace ExtraGeoCustomisation.Utils
{
    internal static class LogEGC
    {
        private static readonly ManualLogSource _Logger;

        static LogEGC()
        {
            _Logger = new ManualLogSource("ExtraGeoCustomisation");
            BepInEx.Logging.Logger.Sources.Add(_Logger);
        }

        private static string Format(object msg) => msg.ToString();
        public static void Info(BepInExInfoLogInterpolatedStringHandler handler)
        {
            if (GlobalConfig.EnableDevLogs)
                _Logger.LogInfo(handler);
        }

        public static void Info(string str)
        {
            if (GlobalConfig.EnableDevLogs)
                _Logger.LogMessage(str);
        }

        public static void Info(object data)
        {
            if (GlobalConfig.EnableDevLogs)
                _Logger.LogMessage(Format(data));
        }

        public static void Debug(BepInExDebugLogInterpolatedStringHandler handler)
        {
            if (GlobalConfig.EnableDevLogs)
                _Logger.LogDebug(handler);
        }

        public static void Debug(string str)
        {
            if (GlobalConfig.EnableDevLogs)
                _Logger.LogDebug(str);
        }

        public static void Debug(object data)
        {
            if (GlobalConfig.EnableDevLogs)
                _Logger.LogDebug(Format(data));
        }

        public static void Error(BepInExErrorLogInterpolatedStringHandler handler)
        {
            if (GlobalConfig.EnableDevLogs)
                _Logger.LogError(handler);
        }

        public static void Error(string str)
        {
            if (GlobalConfig.EnableDevLogs)
                _Logger.LogError(str);
        }

        public static void Error(object data)
        {
            if (GlobalConfig.EnableDevLogs)
                _Logger.LogError(Format(data));
        }

        public static void Fatal(BepInExFatalLogInterpolatedStringHandler handler)
        {
            if (GlobalConfig.EnableDevLogs)
                _Logger.LogFatal(handler);
        }

        public static void Fatal(string str)
        {
            if (GlobalConfig.EnableDevLogs)
                _Logger.LogFatal(str);
        }

        public static void Fatal(object data)
        {
            if (GlobalConfig.EnableDevLogs)
                _Logger.LogFatal(Format(data));
        }

        public static void Warn(BepInExWarningLogInterpolatedStringHandler handler)
        {
            if (GlobalConfig.EnableDevLogs)
                _Logger.LogWarning(handler);
        }

        public static void Warn(string str)
        {
            if (GlobalConfig.EnableDevLogs)
                _Logger.LogWarning(str);
        }

        public static void Warn(object data)
        {
            if (GlobalConfig.EnableDevLogs)
                _Logger.LogWarning(Format(data));
        }

        public static void InfoImportant(BepInExInfoLogInterpolatedStringHandler handler) => _Logger.LogInfo(handler);
        public static void InfoImportant(string str) => _Logger.LogMessage(str);
        public static void InfoImportant(object data) => _Logger.LogMessage(Format(data));
        public static void DebugImportant(BepInExDebugLogInterpolatedStringHandler handler) => _Logger.LogDebug(handler);
        public static void DebugImportant(string str) => _Logger.LogDebug(str);
        public static void DebugImportant(object data) => _Logger.LogDebug(Format(data));
        public static void ErrorImportant(BepInExErrorLogInterpolatedStringHandler handler) => _Logger.LogError(handler);
        public static void ErrorImportant(string str) => _Logger.LogError(str);
        public static void ErrorImportant(object data) => _Logger.LogError(Format(data));
        public static void FatalImportant(BepInExFatalLogInterpolatedStringHandler handler) => _Logger.LogFatal(handler);
        public static void FatalImportant(string str) => _Logger.LogFatal(str);
        public static void FatalImportant(object data) => _Logger.LogFatal(Format(data));
        public static void WarnImportant(BepInExWarningLogInterpolatedStringHandler handler) => _Logger.LogWarning(handler);
        public static void WarnImportant(string str) => _Logger.LogWarning(str);
        public static void WarnImportant(object data) => _Logger.LogWarning(Format(data));

        [Conditional("DEBUG")]
        public static void DebugOnly(object data)
        {
#if DEBUG
            _Logger.LogDebug(Format(data));
#endif
        }
    }
}
