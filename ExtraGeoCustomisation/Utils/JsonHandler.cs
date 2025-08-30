using ExtraGeoCustomisation.Data;
using MTFO.API;
using System.Collections.Generic;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ExtraGeoCustomisation.Utils
{
    internal class JsonHandler
    {
        private static string EGC_CustomPath;
        public static void SetupJson()
        {
            if (!MTFOPathAPI.HasCustomPath)
            {
                LogEGC.Error("MTFO Custom path does not exist please ensure one exists before continuing");
                return;
            }

            EGC_CustomPath = Path.Combine(MTFOPathAPI.CustomPath, "ExtraGeoCustomisations");
            
            if (!Directory.Exists(EGC_CustomPath))
            {
                Directory.CreateDirectory(EGC_CustomPath);
            }

            LogEGC.Info("EGC Custom path loaded");

            MTFOHotReloadAPI.OnHotReload += OnHotReload;

            LoadJson();
        }

        public static Dictionary<int, GeoCustomisationData> GeoCustomisationData = new();

        internal static void LoadJson()
        {
            string[] paths = [];

            LogEGC.Info("Loading Json Data");

            if (!Directory.Exists(EGC_CustomPath))
            {
                Directory.CreateDirectory(EGC_CustomPath);
            }
            paths = Directory.GetFiles(EGC_CustomPath);
            GeoCustomisationData.Clear();
            if (paths.Length > 0)
            {
                foreach (string path in paths)
                {
                    if (path.Contains("Template"))
                    {
                        LogEGC.Info("Tried loading template file aborting");
                        continue;
                    }
                    LogEGC.Info("Loading file with path: " + path);
                    GeoCustomisationData data = Deserialize(path, new GeoCustomisationData());
                    bool t = GeoCustomisationData.TryAdd(data.LevelLayoutID, data);
                    if (t)
                    {
                        LogEGC.ErrorImportant("Tried adding a file to the dictionary that already exists path: " + path);
                    }
                }
            }
            else
            {
                LogEGC.Info("Generating template LevelSpecificGeoData file as no files exist");
                GeoCustomisationData data = DeserializeJsonAndCreateIfNotReal(EGC_CustomPath + "/Template.json", new GeoCustomisationData());
                GeoCustomisationData.Add(data.LevelLayoutID, data);
            }

            if (GlobalConfig.GenerateTemplateFile)
            {
                LogEGC.Info("Generating new template files");
                GlobalConfig.GenerateTemplateFile = false;
                DeserializeAndOverwriteIfReal(EGC_CustomPath + "/Template.json", new GeoCustomisationData());
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

        private static T DeserializeAndOverwriteIfReal<T>(string jsonPath, T data)
        {
            if (File.Exists(jsonPath))
            {
                File.Delete(jsonPath);
            }
            var jsonData = JsonSerializer.Serialize(data, _setting);
            File.WriteAllText(jsonPath, jsonData);
            string codedJson = File.ReadAllText(jsonPath);
            return JsonSerializer.Deserialize<T>(codedJson, _setting);
        }

        private static void OnHotReload()
        {
            LogEGC.Info("Reloading json");
            LoadJson();
            EntryPoint.geoHandler.OnHotReload();
        }

        private static readonly JsonSerializerOptions _setting = new()
        {
            ReadCommentHandling = JsonCommentHandling.Skip,
            IncludeFields = true,
            PropertyNameCaseInsensitive = true,
            WriteIndented = true,
            IgnoreReadOnlyProperties = true,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            Converters = { new BaseCustomisationConverter() },
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        };
    }
}
