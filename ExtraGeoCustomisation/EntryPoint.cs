using BepInEx;
using BepInEx.Unity.IL2CPP;
using ExtraGeoCustomisation.CustomGeo;
using ExtraGeoCustomisation.Patches;
using ExtraGeoCustomisation.Utils;
using GTFO.API;
using Il2CppInterop.Runtime.Injection;

namespace ExtraGeoCustomisation
{
    [BepInDependency("com.dak.MTFO", BepInDependency.DependencyFlags.HardDependency)]
    [BepInPlugin("ExtraGeoCustomisation.GUID", "ExtraGeoCustomisation", "1.0.0")]
    internal class EntryPoint : BasePlugin
    {
        public override void Load()
        {
            LogEGC.Info("Loading ExtraGeoCustomization");
            LevelGenPatches.Setup();
            AssetAPI.OnAssetBundlesLoaded += RegisterTypes;
            CustomGeoHandler geoData = new CustomGeoHandler();
            geoData.Setup();
        }

        private static void RegisterTypes()
        {
            ClassInjector.RegisterTypeInIl2Cpp<CustomGeoCustomisation>();
        }
    }
}
