using ExtraGeoCustomisation.Data;
using UnityEngine;

namespace ExtraGeoCustomisation.Handlers.Customisations
{
    public class CustomisationHandlerBase : MonoBehaviour
    {
        public virtual void Setup(BaseCustomisation data)
        {

        }

        public virtual void ChangeState(eCustomisationState newState, BaseCustomisation newData)
        {

        }


        public enum eCustomisationState
        {
            None = 0,
            Enable = 1,
            Disable = 2,
            Trigger = 3,
            Update = 4,




        }
    }
}
