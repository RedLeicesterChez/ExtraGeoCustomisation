using System.Text.Encodings.Web;
using System.Text.Json;
using System.IO;
using ExtraGeoCustomisation.Utils;
using MTFO.API;
using UnityEngine;
using System.Linq;

namespace ExtraGeoCustomization.Utils
{
    public class JsonHandler
    {
        private static string EGC_CustomPath;
        public static void SetupJson()
        {
            if (!MTFOPathAPI.HasCustomPath)
            {
                LogEGC.Error("MTFO Custom path does not exist please ensure one exists before continuing");
                return;
            }

            EGC_CustomPath = Path.Combine(MTFOPathAPI.CustomPath, "ExtraRundownCustomisation");

            if (!Directory.Exists(EGC_CustomPath))
            {
                Directory.CreateDirectory(EGC_CustomPath);
            }

            LogEGC.Info("ERC Custom path loaded");

            MTFOHotReloadAPI.OnHotReload += OnHotReload;

            LoadJson();
        }

        private static string[] globalGeoDataPaths;
        private static string[] perLevelDataPaths;

        private static void LoadJson(bool isHotReload = false, bool generateTemplate = false)
        {
            LogEGC.Info("Loading Json Data");
            if (!Directory.Exists(EGC_CustomPath + "/GlobalGeoData"))
            {
                Directory.CreateDirectory(EGC_CustomPath + "/GlobalGeoData");
            }

            globalGeoDataPaths = Directory.GetFiles(EGC_CustomPath + "/GlobalGeoData");

            if (generateTemplate)
            {
                LogEGC.Debug("Adding template files");
                //File.WriteAllText(EGC_CustomPath + "/GlobalGeoData");
            }

            LogEGC.Info("Json data Loaded");

            if (isHotReload)
            {

            }
        }

        private static T DeserializeJsonAndCreateIfNotReal<T>(string jsonPath, T data)
        {
            if (!File.Exists(jsonPath))
            {
                var jsonData = JsonSerializer.Serialize(data, _setting);
                File.WriteAllText(jsonPath, jsonData);
            }
            string codedJson = File.ReadAllText(jsonPath);
            return JsonSerializer.Deserialize<T>(codedJson, _setting);
        }

        private static T Deserialize<T>(string jsonPath, T data)
        {
            if (!File.Exists(jsonPath))
            {
                LogEGC.Error("Tried to load a JSON file that doesn't exist");
                return default;
            }
            string codedJson = File.ReadAllText(jsonPath);
            return JsonSerializer.Deserialize<T>(codedJson, _setting);
        }

        public static void OnHotReload()
        {
            LogEGC.Info("Reloading json");
            LoadJson(true);
        }

        private static readonly JsonSerializerOptions _setting = new()
        {
            ReadCommentHandling = JsonCommentHandling.Skip,
            IncludeFields = true,
            PropertyNameCaseInsensitive = true,
            WriteIndented = true,
            IgnoreReadOnlyProperties = true,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        };
    }
}
