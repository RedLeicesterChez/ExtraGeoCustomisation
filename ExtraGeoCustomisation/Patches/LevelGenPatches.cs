using ExtraGeoCustomisation.Utils;
using HarmonyLib;
using LevelGeneration;
using System;
using UnityEngine;

namespace ExtraGeoCustomisation.Patches
{
    internal static class LevelGenPatches
    {
        public static void Setup(Harmony harmony)
        {
            LogEGC.Info("Patching LevelGen");
            harmony.PatchAll(typeof(Patch_LG_LevelBuilder_PlaceRoot));
        }

        [HarmonyPatch(typeof(LG_LevelBuilder), "PlaceRoot")]
        private class Patch_LG_LevelBuilder_PlaceRoot
        {
            public static void Prefix(ref GameObject tilePrefab, LG_Floor floor, eDimensionIndex dimensionIndex)
            {
                LogEGC.Info("Placing root tileprefab \nname: " + tilePrefab.name + "\nFloor: " + floor);
                GameObject modifiedGeo = EntryPoint.geoHandler.OnPlaceRoot(tilePrefab, floor, dimensionIndex);
                if (modifiedGeo != null)
                {
                    tilePrefab = modifiedGeo;
                }
            }
        }
    }
}