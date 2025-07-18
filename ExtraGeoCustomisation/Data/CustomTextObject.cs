namespace ExtraGeoCustomization.Data
{
    [System.Serializable]
    public class CustomTextObject : BaseCustomisation
    {
        public string Text { get; set; }
        public int FontSize { get; set; }
        public Color TextColor { get; set; }
        public Vector4 Margins { get; set; }
        public eFontAsset FontAsset { get; set; }
        public eFontType FontType { get; set; }

        [System.Serializable]
        public enum eFontAsset
        {
            FireMono = 0,
            LiberationSans = 3,
        }

        [System.Serializable]
        public enum eFontType
        {
            Bold = 0,
            Italic = 1,
            Underline = 2,
            Strikethrough = 3,
            Lowercase = 4,
            Uppercase = 5,
            Smallcaps = 6,
        }
    }
}
