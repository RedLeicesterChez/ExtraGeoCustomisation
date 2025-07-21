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
            harmony.PatchAll(typeof(Patch_LG_Factory_FactoryDone));
            harmony.PatchAll(typeof(Patch_WardenObjectiveManager_OnLocalPlayerStartExpedition));
            harmony.PatchAll(typeof(Patch_WardenObjectiveManager_OnLocalPlayerSolvedObjectiveItem));
            harmony.PatchAll(typeof(Patch_WardenObjectiveManager_ActivateWinCondition));
            harmony.PatchAll(typeof(Patch_GS_AfterLevel_CleanupAfterExpedition));
            harmony.PatchAll(typeof(Patch_LG_LevelBuilder_PlaceRoot));
        }

        [HarmonyPatch(typeof(LG_LevelBuilder), "PlaceRoot")]
        private class Patch_LG_LevelBuilder_PlaceRoot
        {
            public static void Postfix(ref GameObject tilePrefab)
            {
                GameObject modifiedGeo = EntryPoint.globalGeoHandler.GetModifiedGeomorph(tilePrefab.name);
                if (modifiedGeo != null)
                {
                    tilePrefab = modifiedGeo;
                }
            }
        }

        [HarmonyPatch(typeof(LG_Factory), "FactoryDone")]
        private class Patch_LG_Factory_FactoryDone
        {
            public static void Postfix()
            {
                OnBuildDone?.Invoke();
            }
        }

        [HarmonyPatch(typeof(WardenObjectiveManager), "OnLocalPlayerStartExpedition")]
        private class Patch_WardenObjectiveManager_OnLocalPlayerStartExpedition
        {
            public static void Postfix()
            {
                OnStartExpedition?.Invoke();
            }
        }

        [HarmonyPatch(typeof(WardenObjectiveManager), "OnLocalPlayerSolvedObjectiveItem")]
        private class Patch_WardenObjectiveManager_OnLocalPlayerSolvedObjectiveItem
        {
            public static void Postfix()
            {
                OnSolvedObjectiveItem?.Invoke();
            }
        }

        [HarmonyPatch(typeof(WardenObjectiveManager), "ActivateWinCondition")]
        private class Patch_WardenObjectiveManager_ActivateWinCondition
        {
            public static void Postfix()
            {
                OnObjectiveComplete?.Invoke();
            }
        }

        [HarmonyPatch(typeof(GS_AfterLevel), "CleanupAfterExpedition")]
        private class Patch_GS_AfterLevel_CleanupAfterExpedition
        {
            public static void Postfix()
            {
                OnLevelCleanup?.Invoke();
            }
        }

        public static event Action OnBuildStart;
        public static event Action OnBuildDone;

        public static event Action OnStartExpedition;
        public static event Action OnSolvedObjectiveItem;
        public static event Action OnObjectiveComplete;
        public static event Action OnLevelCleanup;
    }
}