namespace ExtraGeoCustomization.Data
{
    [System.Serializable]
    public class CustomTextObject
    {
        public string Text { get; set; }
        public int fontSize { get; set; }
        public Color textColor { get; set; }
        public Vector4 margins { get; set; }
        public eFontAsset fontAsset { get; set; }
        public eFontType fontType { get; set; }

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
