using ExtraGeoCustomisation.Data;
using ExtraGeoCustomisation.Utils;
using UnityEngine;

namespace ExtraGeoCustomisation.Handlers.Customisations
{
    public class ShuttleBoxHandler : MonoBehaviour
    {
        public ShuttleBox data;
        public void Setup(BaseCustomisation baseData)
        {
            data = baseData as ShuttleBox;
            if (data == null)
            {
                LogEGC.ErrorImportant("Tried setting up TextObject and data was null go name: " + gameObject.name);
                return;
            }
            LogEGC.Info("Setup Custom Text object with go name: " + gameObject.name);
            //Instantiate shuttlebox
        }
    }
}
