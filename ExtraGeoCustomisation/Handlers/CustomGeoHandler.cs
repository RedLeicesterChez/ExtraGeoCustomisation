using ExtraGeoCustomisation.Patches;
using ExtraGeoCustomisation.Utils;
using GTFO.API;
using LevelGeneration;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace ExtraGeoCustomisation.Handlers
{
    public class CustomGeoHandler
    {
        public void Setup()
        {
            //LevelGenPatches.OnBuildDone += OnLevelGenDone;
            //LevelGenPatches.OnStartExpedition += OnLevelGenDone;
        }

        public void GetLoadedAsset(string path)
        {
            UnityEngine.Object loadedAsset = AssetAPI.GetLoadedAsset(path);
        }

        //TODO: Redo this entire thing it is no longer sufficient
        private void OnLevelGenDone()
        {
            LG_Floor levelFloor = Builder.CurrentFloor;
            for (int i = 0; i < levelFloor.m_dimensions.Count; i++)
            {
                for (int f = 0; f < levelFloor.transform.GetChild(i).childCount; f++)
                {
                    LogEGC.Info("Detected geomorph in children \ndimension index: " + i + "\nchild index: " + f);
                    if (levelFloor.transform.GetChild(i).GetChild(f).gameObject == null)
                    {
                        LogEGC.Error("geo was null this should not happen");
                        continue;
                    }
                    geoList.Add(levelFloor.transform.GetChild(i).GetChild(f).gameObject.AddComponent<CustomGeoCustomisation>());
                    //LogEGC.Info("Added comp to a geo");
                }
            }

            int index = 0;
            foreach (var geo in geoList)
            {
                if (geo == null)
                {
                    LogEGC.Error("geo in geo list was null this should not happen");
                    continue;
                }
                if (geo.gameObject == null)
                {
                    LogEGC.Error("geo gameobject was null this should not happen");
                    continue;
                }
                LogEGC.Info("setting up custom geo behaviour");
                try
                {
                    geo.Setup(index);
                }
                catch (Exception e)
                {
                    LogEGC.Error($"Exception during geo.Setup({index}): {e}");
                }
                index++;
            }



        }


        private static List<CustomGeoCustomisation> geoList = new List<CustomGeoCustomisation>();

    }

    public class CustomGeoCustomisation : MonoBehaviour
    {
        public int geoIndex = 0;
        private List<LG_WorldEventObject> worldEventObjects;
        private LG_Geomorph geoComp;
        private bool isSetup = false;
        public bool isGloballyModified = false;
        public void Setup(int index)
        {
            //LogEGC.Info("setup called");
            if (isSetup) //for late setup code if needed
            {
                return;
            }
            geoIndex = index;
            //LogEGC.Info("index set");
            LG_Geomorph geo = gameObject.GetComponent<LG_Geomorph>();
            //LogEGC.Info("getComponent called");
            if (geo == null)
            {
                LogEGC.Error("geo comp is null aborting");
                return;
            }
            geoComp = geo;
            //LogEGC.Info("got geo comp");

            if (geoComp.m_zone == null)
            {
                LogEGC.Info("Geo comp was probably an elevator tile setting up as one");
                SetupAsElevator();
                return;
            }

            if (geoComp == null)
            {
                LogEGC.Error("geoComp was null");
                return;
            }
            isSetup = true;

            if (GlobalConfig.EnableDevLogs)
            {
                LogEGC.Info("Set up geomorph with name: " + gameObject.name + "\nLocalIndex: " + geoComp.m_zone.LocalIndex + "\nGeoIndex: " + geoIndex);
            }
            //LogEGC.Info("passed log");

            LG_WorldEventObject[] weos = [];
            weos = geoComp.gameObject.GetComponentsInChildren<LG_WorldEventObject>();
            LogEGC.Info("getting components in children");
            foreach (var weo in weos)
            {
                if (weo == null)
                {
                    LogEGC.Error("world event object was null");
                    continue;
                }
                worldEventObjects.Add(weo);
                if (GlobalConfig.EnableDevLogs)
                {
                    LogEGC.Info("Registered world event object with name: " + weo.name + "\ngeoIndex: " + geoIndex + "\ngeoName: " + gameObject.name);
                }
            }

            LogEGC.Info("Finished setting up geo");
        }

        private void SetupAsElevator()
        {
            if (GlobalConfig.EnableDevLogs)
            {
                LogEGC.Info("Set up elevator tile with name: " + gameObject.name + "\nGeoIndex: " + geoIndex);
            }
        }
    }
}
