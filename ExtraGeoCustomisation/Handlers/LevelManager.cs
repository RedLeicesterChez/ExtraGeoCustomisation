using LevelGeneration;
using System;

namespace ExtraGeoCustomisation.Handlers
{
    internal class LevelManager
    {
        public void Setup()
        {
            LG_Factory.add_OnFactoryBuildStart((Action)SetupCustomLevel);
        }

        public void SetupCustomLevel()
        {

        }
    }
}
