using ExtraGeoCustomisation.Utils;
using ExtraGeoCustomization.Data;
using GTFO.API;
using LevelGeneration;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ExtraGeoCustomization.Handlers
{
    public class GlobalGeoHandler
    {
        public void Setup()
        {
            
        }

        public void LoadGlobalGeos(bool isReload = false)
        {
            if (isReload)
            {
                LoadedGeos.Clear();
            }

            foreach (GlobalGeoData data in JsonHandler.GlobalGeoDatas)
            {
                GameObject geo = GetAndModifyGeo(data.GeoPath, data.Customisations);
                LoadedGeos.Add(geo);
            }
        }
        //Are internal fields hidden?
        public List<GameObject> LoadedGeos = new();

        private GameObject GetAndModifyGeo(string geoPath, BaseCustomisation[] Customisations)
        {
            UnityEngine.Object obja = null;
            obja = AssetAPI.GetLoadedAsset(geoPath);

            if (obja != null)
            {
                GameObject obj = obja.TryCast<GameObject>();
                obj.name = obj.name + "Modified";
                //TODO: Add customisation stuff (Customisations will be created when the geo is built but
                //registered beforehand)
                List<LG_WorldEventObject> weos = new();

                //Not sure if i should include inactive children but I might add a config later
                weos = [.. obj.GetComponentsInChildren<LG_WorldEventObject>(true)];

                foreach (LG_WorldEventObject weo in weos)
                {
                    LogEGC.Info("Found world event object with name: " + weo.gameObject.name);
                }

                





                LogEGC.Info("Returning obj with name: " + obj.name);
                return obj;
            }
            else
            {
                LogEGC.Error("Couldn't get geo from path: " + geoPath + "\nWrong path or missing bundle?");
                return null;
            }
        }
    }
}
