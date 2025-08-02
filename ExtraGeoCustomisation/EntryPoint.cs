using BepInEx;
using BepInEx.Unity.IL2CPP;
using ExtraGeoCustomisation.Handlers;
using ExtraGeoCustomisation.Patches;
using ExtraGeoCustomisation.Utils;
using ExtraGeoCustomisation.Handlers.Customisations;
using GTFO.API;
using HarmonyLib;
using Il2CppInterop.Runtime.Injection;

namespace ExtraGeoCustomisation
{
    [BepInDependency("com.dak.MTFO", BepInDependency.DependencyFlags.HardDependency)]
    [BepInPlugin("ExtraGeoCustomisation.GUID", "ExtraGeoCustomisation", "1.0.0")]
    internal class EntryPoint : BasePlugin
    {
        internal static GlobalGeoHandler globalGeoHandler;
        internal static LevelManager levelManager;
        private static Harmony _Harmony;
        public override void Load()
        {
            LogEGC.Info("Loading ExtraGeoCustomisation");
            _Harmony = new Harmony("ExtraGeoCustomisation.Harmony");
            globalGeoHandler = new GlobalGeoHandler();
            LevelGenPatches.Setup(_Harmony);
            AssetAPI.OnAssetBundlesLoaded += RegisterTypes;
            AssetAPI.OnAssetBundlesLoaded += OnAssetsLoaded;
            JsonHandler.SetupJson();
            //CustomGeoHandler geoData = new CustomGeoHandler();
            //geoData.Setup();

            CConsoleUtils.RegisterCommands();
        }

        private static void RegisterTypes()
        {
            //ClassInjector.RegisterTypeInIl2Cpp<CustomGeoCustomisation>();
            ClassInjector.RegisterTypeInIl2Cpp<CustomisationHandlerBase>();
            ClassInjector.RegisterTypeInIl2Cpp<TextObjectHandler>();
        }

        private static void OnAssetsLoaded()
        {
            globalGeoHandler.LoadGlobalGeos();
        }
    }
























    /*
    [HarmonyPatch(typeof(Dam_EnemyDamageLimb))]
    public static class EnemyDamageLimbPatches
    {

        [HarmonyPatch(nameof(Dam_EnemyDamageLimb.MeleeDamage))]
        [HarmonyPrefix]
        public static void MeleePrefix(Dam_EnemyDamageLimb __instance, ref float dam, Agent sourceAgent)
        {
            LogManager.Debug($"Received MeleeDamage");
            if (!__instance.m_base.Owner.Alive)
                return;
            
            if (sourceAgent != null)
            {
                LogManager.Debug($"Source Agent was not null");
                if (sourceAgent.IsLocallyOwned)
                {
                    LogManager.Debug($"Source Agent is Locally Owned");
                    var damage = dam;
                    LogManager.Debug($"Melee damage from local player registered. {damage} was scaled up to:");
                    damage *= CacheApiWrapper.GetActiveLevel().MeleeDamageMultiplier;
                    LogManager.Debug($"{damage}");
                    dam = damage;
                    CustomScalingBuff? buff = CacheApiWrapper.GetActiveLevel().CustomScaling.FirstOrDefault(buff => buff.CustomBuff == CustomScaling.MeleeLifesteal);
                    if (buff != null)
                    {
                        var playerAgent = sourceAgent.Cast<PlayerAgent>();
                        playerAgent.Damage.AddHealth(damage * buff.Value * playerAgent.Damage.HealthMax / 100, playerAgent);
                    }
                }
            }
        }

        [HarmonyPatch(nameof(Dam_EnemyDamageLimb.BulletDamage))]
        [HarmonyPrefix]
        public static void BulletPostfix(Dam_EnemyDamageLimb __instance, ref float dam, Agent sourceAgent)
        {
            if (!__instance.m_base.Owner.Alive)
                return;

            if (sourceAgent != null)
            {
                if (sourceAgent.IsLocallyOwned && !SentryGunCheckPatches.SentryShot)
                {
                    var damage = dam;
                    LogManager.Debug($"Bullet damage from local player registered. {damage} was scaled to:");
                    damage *= CacheApiWrapper.GetActiveLevel().WeaponDamageMultiplier;
                    LogManager.Debug($"{damage}");
                    dam = damage;
                    CustomScalingBuff? buff = CacheApiWrapper.GetActiveLevel().CustomScaling.FirstOrDefault(buff => buff.CustomBuff == CustomScaling.GunLifesteal);
                    if (buff != null)
                    {
                        var playerAgent = sourceAgent.Cast<PlayerAgent>();
                        playerAgent.Damage.AddHealth(damage * buff.Value * playerAgent.Damage.HealthMax / 100, playerAgent);
                    }
                }
            }
        }
    }*/
}
