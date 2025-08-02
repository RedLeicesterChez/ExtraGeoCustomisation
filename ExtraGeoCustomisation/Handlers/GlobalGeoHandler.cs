using AssetShards;
using ExtraGeoCustomisation.Utils;
using ExtraGeoCustomisation.Data;
using ExtraGeoCustomisation.Handlers.Customisations;
using GameData;
using GTFO.API;
using LevelGeneration;
using System.Collections.Generic;
using UnityEngine;

namespace ExtraGeoCustomisation.Handlers
{
    internal class GlobalGeoHandler
    {
        public void LoadGlobalGeos(bool isReload = false)
        {
            if (isReload)
            {
                LoadedGeos.Clear();
            }

            foreach (GlobalGeoData data in JsonHandler.GlobalGeoDatas)
            {
                GetAndModifyGeo(data.GeoPath, data.Customisations);
            }
        }

        public Dictionary<string, GameObject> LoadedGeos = new();

        private void GetAndModifyGeo(string geoPath, BaseCustomisation[] Customisations)
        {
            UnityEngine.Object obja = null;
            obja = AssetAPI.GetLoadedAsset(geoPath);
            //TODO: Add compatability for vanilla geos (probably has to be done when we load the level)

            if (obja != null)
            {
                GameObject obj = obja.TryCast<GameObject>();
                obj.name = obj.name + "Modified";

                List<LG_WorldEventObject> weos = new();

                //Not sure if i should include inactive children but I might add a config later
                weos = [.. obj.GetComponentsInChildren<LG_WorldEventObject>(true)];

                foreach (LG_WorldEventObject weo in weos)
                {
                    GameObject weoObject = weo.gameObject;
                    LogEGC.Info("Found world event object with name: " + weoObject.name);
                    BaseCustomisation customisation = DataUtils.GetCustomisationWithName(weoObject.name, Customisations);

                    switch (customisation.Type)
                    {
                        case eCustomisationType.TextObject:
                        {
                            weoObject.AddComponent<TextObjectHandler>().Setup(customisation);
                        }
                        break;
                    }
                }




                LogEGC.Info("Adding obj to the dictionary with name: " + obj.name);
                LoadedGeos.Add(obja.name, obj);
            }
            else
            {
                LogEGC.ErrorImportant("Couldn't get geo from path: " + geoPath + "\nWrong path or missing bundle?");
            }
        }

        public GameObject GetModifiedGeomorph(string originalPath)
        {
            if (LoadedGeos.ContainsKey(originalPath))
            {
                LogEGC.Info("returning modified geo path: " + originalPath);
                return LoadedGeos[originalPath];
            }
            LogEGC.Error("Couldn't get modified geo original path: " + originalPath);
            return null;
        }
    }
}
