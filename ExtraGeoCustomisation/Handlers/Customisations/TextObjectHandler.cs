using ExtraGeoCustomisation.Utils;
using ExtraGeoCustomisation.Data;
using TMPro;

namespace ExtraGeoCustomisation.Handlers.Customisations
{
    public class TextObjectHandler : CustomisationHandlerBase
    {
        public TextObject data;
        public TextMeshPro tmp;
        public override void Setup(BaseCustomisation baseData)
        {
            data = baseData as TextObject;
            if (data == null)
            {
                LogEGC.ErrorImportant("Tried setting up TextObject and data was null go name: " + gameObject.name);
                return;
            }
            LogEGC.Info("Setup Custom Text object with go name: " + gameObject.name);
            tmp = gameObject.AddComponent<TextMeshPro>();
            UpdateText(data);
        }

        public override void ChangeState(eCustomisationState newState, BaseCustomisation newData)
        {
            switch (newState)
            {
                case eCustomisationState.Update:
                {
                    UpdateText(newData);
                }
                break;
                case eCustomisationState.Enable:
                {
                    tmp.enabled = true;
                }
                break;
                case eCustomisationState.Disable:
                {
                    tmp.enabled = false;
                }
                break;
            }
        }

        private void UpdateText(BaseCustomisation baseData)
        {
            data = baseData as TextObject;
            if (data == null)
            {
                LogEGC.ErrorImportant("Tried updating TextObject and data was null go name: " + gameObject.name);
                return;
            }
            tmp.text = data.Text;
            tmp.fontSize = data.FontSize;
            tmp.color = new UnityEngine.Color(data.TextColor.r, data.TextColor.g, data.TextColor.b, data.TextColor.a);
            tmp.margin = new UnityEngine.Vector4(data.Margins.x, data.Margins.y, data.Margins.z, data.Margins.w);

            if (data.FontAsset != eFontAsset.LiberationSans)
            {
                //TODO: This needs finishing but need to finish GetFontAsset first
                tmp.font = DataUtils.GetFontAsset(data.FontAsset);
            }

            switch (data.FontType)
            {
                case eFontType.Italic:
                {
                    tmp.fontStyle = FontStyles.Italic;
                }
                break;
                case eFontType.Uppercase:
                {
                    tmp.fontStyle = FontStyles.UpperCase;
                }
                break;
                case eFontType.Lowercase:
                {
                    tmp.fontStyle = FontStyles.LowerCase;
                }
                break;
                case eFontType.Underline:
                {
                    tmp.fontStyle = FontStyles.Underline;
                }
                break;
                case eFontType.Bold:
                {
                    tmp.fontStyle = FontStyles.Bold;
                }
                break;
                case eFontType.Smallcaps:
                {
                    tmp.fontStyle = FontStyles.SmallCaps;
                }
                break;
                case eFontType.Strikethrough:
                {
                    tmp.fontStyle = FontStyles.Strikethrough;
                }
                break;
            }
        }
    }
}
