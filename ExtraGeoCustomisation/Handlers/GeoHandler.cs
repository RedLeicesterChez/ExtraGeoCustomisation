using ExtraGeoCustomisation.Data;
using ExtraGeoCustomisation.Handlers.Customisations;
using ExtraGeoCustomisation.Utils;
using GTFO.API;
using LevelGeneration;
using System.Collections.Generic;
using UnityEngine;

namespace ExtraGeoCustomisation.Handlers
{
    internal class GeoHandler
    {
        public void Setup()
        {
            LogEGC.Info("Setup GeoHandler");
            LevelAPI.OnAfterBuildBatch += LoadResourcesShards_Level;
        }

        public void OnHotReload()
        {

        }

        private eDimensionIndex currentIndex;
        private LG_Floor currentFloor;
        private int geoIndex = 0;
        private bool CustomiseLevel = false;

        public GameObject OnPlaceRoot(GameObject original, LG_Floor floor, eDimensionIndex dimension)
        {
            if (geoIndex == 0)
            {
                currentIndex = dimension;
                currentFloor = floor;
            }
            if (currentFloor != floor)
            {
                currentFloor = floor;
            }
            if (currentIndex != dimension)
            {
                currentIndex = dimension;
            }
            LogEGC.Info("Placing geo \ngeoIndex: " + geoIndex + "\nfloor: " + floor.name + "\ndimension: " + dimension);

            LocalGeoData data = null;
            try
            {
                GeoCustomisationData.TryGetValue(geoIndex, out data);
            }
            catch
            {
                LogEGC.ErrorImportant("Failed to get value from geo customisation datas");
            }

            if (data == null)
            {
                LogEGC.ErrorImportant("data was null returning null");
                return null;
            }
            GameObject modified = ModifyGeo(ref original, data.Customisations);
            geoIndex++;
            if (modified != null)
            {
                return modified;
            }
            return null;
        }

        public static void LoadResourcesShards_Level(LG_Factory.BatchName batchName)
        {
            if (batchName != LG_Factory.BatchName.LoadResourcesShards_Level)
            {
                return;
            }

            for (int i = JsonHandler.GeoCustomisationData.Count; i > 0; i--)
            {
                //FIXME: This is probably nulling and fucking shit up
                GeoCustomisationData data;
                JsonHandler.GeoCustomisationData.TryGetValue(i, out data);

                if (data.LevelLayoutID == RundownManager.ActiveExpedition.LevelLayoutData)
                {
                    EntryPoint.geoHandler.CustomiseLevel = true;
                    EntryPoint.geoHandler.LoadCustomisationData(data);
                }
            }
        }

        //In an ideal world we modify all geos needed when the game is loaded
        //But It's easier to modify them when we're placing the geos as we can
        //replace the exact one we need

        //Geo name template
        //ORIGINAL_NAME_64x64 + _MODIFIED + _GEOINDEX
        //Geos are stored with the geo index anyway
        private Dictionary<int, LocalGeoData> GeoCustomisationData;

        public void LoadCustomisationData(GeoCustomisationData data)
        {
            GeoCustomisationData.Clear();
            foreach (var geo in data.GeoDatas)
            {
                GeoCustomisationData.Add(geo.geoIndex, geo);
            }
        }

        private GameObject ModifyGeo(ref GameObject geo, BaseCustomisation[] customisations)
        {
            List<LG_WorldEventObject> weos = [.. geo.GetComponentsInChildren<LG_WorldEventObject>()];

            //Get custom world event objects first to avoid object order stuff
            foreach (var cust1 in customisations)
            {
                if (cust1 is WorldEventObject weoData)
                {
                    GameObject cWeo = Object.Instantiate(new GameObject(), geo.transform);
                    cWeo.AddComponent<LG_WorldEventObject>();
                    cWeo.transform.position = new UnityEngine.Vector3(weoData.Position.x, weoData.Position.y, weoData.Position.z);
                    cWeo.transform.rotation = new UnityEngine.Quaternion(weoData.Rotation.x, weoData.Rotation.y, weoData.Rotation.z, 0);
                    weos.Add(cWeo.GetComponent<LG_WorldEventObject>());
                }
            }

            foreach (var weo in weos)
            {
                BaseCustomisation cust = DataUtils.GetCustomisationWithName(weo.name, customisations);

                switch (cust.Type)
                {
                    case eCustomisationType.TextObject:
                    {
                        weo.gameObject.AddComponent<TextObjectHandler>().Setup(cust);
                    }
                    break;


                    default:
                    {
                        LogEGC.Info("Got no customisation of type");
                    }
                    break;
                }
            }



            return null;
        }






        /*
        //Key is the original name GO is the modified GO
        public static Dictionary<string, GameObject> ModifiedGeos = new();

        public void Setup()
        {
            LogEGC.Info("Setup GeoHandler");
            LevelGenPatches.OnBuildStart += OnLevelStart;
            //Although it's technically possible for geo placement to happen faster than we modify
            //and add them to the list i sincerely doubt this will ever happen
        }

        public void OnLevelStart()
        {
            ModifiedGeos.Clear();

            SetupGlobalGeos();
        }

        public void SetupGlobalGeos()
        {
            foreach (var data in JsonHandler.GlobalGeoDatas)
            {
                ModifyAndAddGeo(data.GeoPath, data.Customisations, true);
            }
        }

        private void ModifyAndAddGeo(string path, BaseCustomisation[] customs, bool isGlobal = false)
        {
            LogEGC.Info("modifying and adding geo Path: " + path + ", isGlobal: " + isGlobal);
            Object obj = AssetAPI.GetLoadedAsset(path);
            GameObject obja = null;

            try
            {
                LogEGC.Info("casting obj as GO");
                obja = obj.TryCast<GameObject>();
            }
            catch { }

            if (obja != null)
            {
                GameObject objb = obja;
                objb.name = obja.name + "_MODIFIED";
                if (isGlobal)
                {
                    objb.name = obja.name + "_GLOBAL";
                }

                List<LG_WorldEventObject> weos = new();

                weos = [.. objb.GetComponentsInChildren<LG_WorldEventObject>(true)];

                foreach (LG_WorldEventObject weo in weos)
                {
                    GameObject weoObject = weo.gameObject;
                    LogEGC.Info("Found world event object with name: " + weoObject.name);
                    BaseCustomisation customisation = DataUtils.GetCustomisationWithName(weoObject.name, customs);

                    if (weoObject == null || customisation == null)
                    {
                        LogEGC.Error("weoObject or customisation was null");
                        continue;
                    }

                    switch (customisation.Type)
                    {
                        case eCustomisationType.TextObject:
                        {
                            weoObject.AddComponent<TextObjectHandler>().Setup(customisation);
                        }
                        break;
                    }
                }

                ModifiedGeos.Add(obja.name, objb);
                LogEGC.Info("Modified Geo with path: " + path + "\nName: " + objb.name);
                return;
            }
            LogEGC.ErrorImportant("Tried to get a geo with an incorrect path \nPath: " + path);
        }

        public GameObject TryGetModifiedGeomorph(string originalName)
        {
            if (ModifiedGeos.ContainsKey(originalName))
            {
                LogEGC.Info("returning modified geo name: " + originalName);
                return ModifiedGeos[originalName];
            }
            LogEGC.Warn("Couldn't get modified geo original name: " + originalName);
            return null;
        }

        //*/
        }
    }
