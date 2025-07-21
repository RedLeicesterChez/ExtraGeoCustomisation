using ExtraGeoCustomisation.Utils;
using ExtraGeoCustomization.Data;
using GTFO.API;
using TMPro;
using UnityEngine;

namespace ExtraGeoCustomization.Utils
{
    internal static class DataUtils
    {
        public static BaseCustomisation GetCustomisationWithName(string name, BaseCustomisation[] customisations)
        {
            if (customisations == null)
            {
                LogEGC.Error("Customisations were null");
                return null;
            }

            //Please tell me there's a better way to do this
            //Maybe some complicated stuff with dictionaries?
            foreach (var customisation in customisations)
            {
                if (customisation.WorldObjectName == name)
                {
                    return customisation;
                }
            }

            LogEGC.Error("Could not find custimisation with name: " + name);
            return null;
        }

        public static TMP_FontAsset GetFontAsset(eFontAsset type)
        {
            switch (type)
            {
                case eFontAsset.LiberationSans:
                {

                }
                break;
                case eFontAsset.ShareTechMono:
                {
                    Object asset = AssetAPI.GetLoadedAsset("Assets/Bundles/Fonts/FiraMono-Regular SDF.asset");
                    if (asset != null)
                    {
                        return asset as TMP_FontAsset;
                    }
                }
                break;
                case eFontAsset.FireMono:
                {
                    Object asset = AssetAPI.GetLoadedAsset("Assets/Bundles/Fonts/FiraMono-Regular SDF.asset");
                    if (asset != null)
                    {
                        return asset as TMP_FontAsset;
                    }
                }
                break;
                


            }




            return null;
        }
    }
}
