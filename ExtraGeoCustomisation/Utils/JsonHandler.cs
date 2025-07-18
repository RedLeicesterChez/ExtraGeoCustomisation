using System.Text.Encodings.Web;
using System.Text.Json;
using System.IO;
using ExtraGeoCustomisation.Utils;
using MTFO.API;
using ExtraGeoCustomization.Data;
using System.Collections.Generic;
using HarmonyLib;
using System;

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

            EGC_CustomPath = Path.Combine(MTFOPathAPI.CustomPath, "ExtraGeoCustomisations");
            
            if (!Directory.Exists(EGC_CustomPath))
            {
                Directory.CreateDirectory(EGC_CustomPath);
            }

            LogEGC.Info("EGC Custom path loaded");

            MTFOHotReloadAPI.OnHotReload += OnHotReload;

            LoadJson();
        }

        //public Dictionary<int, BaseCustomisation[]> Customisations; For individual customisations (put elsewhere)
        public static List<GlobalGeoData> GlobalGeoDatas = new();
        public static List<LevelSpecificGeoData> LevelSpecificGeoDatas = new();

        private static void LoadJson(bool isHotReload = false, bool generateTemplate = false)
        {
            string globalDataPath = Path.Combine(EGC_CustomPath + "/GlobalData");
            string levelSpecificDataPath = Path.Combine(EGC_CustomPath + "/LevelSpecificData");

            string[] globalGeoDataPaths = [];
            string[] perLevelDataPaths = [];

            LogEGC.Info("Loading Json Data");

            if (!Directory.Exists(globalDataPath))
            {
                Directory.CreateDirectory(globalDataPath);
            }
            globalGeoDataPaths = Directory.GetFiles(globalDataPath);
            if (globalGeoDataPaths.Length > 0)
            {
                foreach (string path in globalGeoDataPaths)
                {
                    LogEGC.Info("Loading file with path: " + path);
                    GlobalGeoData data = Deserialize(path, new GlobalGeoData());
                    GlobalGeoDatas.Add(data);
                }
            }
            else
            {
                LogEGC.Info("Generating template file as no files exist");
                GlobalGeoData data = DeserializeJsonAndCreateIfNotReal(globalDataPath + "/Template.json", new GlobalGeoData());
            }

            if (!Directory.Exists(levelSpecificDataPath))
            {
                Directory.CreateDirectory(levelSpecificDataPath);
            }
            perLevelDataPaths = Directory.GetFiles(levelSpecificDataPath);
            if (perLevelDataPaths.Length > 0)
            {
                foreach (string path in perLevelDataPaths)
                {
                    LogEGC.Info("Loading file with path: " + path);
                    LevelSpecificGeoData data = Deserialize(path, new LevelSpecificGeoData());
                    LevelSpecificGeoDatas.Add(data);
                }
            }
            else
            {
                LogEGC.Info("Generating template file as no files exist");
                LevelSpecificGeoData data = DeserializeJsonAndCreateIfNotReal(levelSpecificDataPath + "/Template.json", new LevelSpecificGeoData());
            }

            if (generateTemplate)
            {
                LogEGC.Info("Generating new template files");
                DeserializeAndOverwriteIfReal(globalDataPath + "/Template.json", new GlobalGeoData());
                DeserializeAndOverwriteIfReal(levelSpecificDataPath + "/Template.json", new LevelSpecificGeoData());

            }


            /*
            if (!Directory.Exists(globalDataPath))
            {
                Directory.CreateDirectory(globalDataPath);
            }
            globalGeoDataPaths = Directory.GetFiles(globalDataPath);

            if (!Directory.Exists(levelSpecificDataPath))
            {
                Directory.CreateDirectory(levelSpecificDataPath);
            }
            perLevelDataPaths = Directory.GetFiles(levelSpecificDataPath);

            if (generateTemplate)
            {
                LogEGC.Debug("Adding template files");
                AddTemplateFiles(globalDataPath, levelSpecificDataPath);
            }

            LogEGC.Info("Json data Loaded");

            if (isHotReload)
            {

            }

            void AddTemplateFiles(string globalDataPath, string LevelSpecificDataPath)
            {

            }
            */
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

        public static void OnHotReload()
        {
            LogEGC.Info("Reloading json");
            //LoadJson(true);
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
        };
    }
}
