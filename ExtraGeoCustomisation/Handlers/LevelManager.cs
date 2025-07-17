using LevelGeneration;
using System;

namespace ExtraGeoCustomization.Handlers
{
    internal class LevelManager
    {
        public static void Setup()
        {

            LG_Factory.add_OnFactoryBuildStart((Action)SetupCustomLevel);
        }

        public static void SetupCustomLevel()
        {

        }
    }
}
