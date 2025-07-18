using System.Text.Json.Serialization;

namespace ExtraGeoCustomization.Data
{
    [System.Serializable]
    public class TextObject : BaseCustomisation
    {
        [JsonPropertyOrder(4)]
        public string Text { get; set; }

        [JsonPropertyOrder(5)]
        public int FontSize { get; set; }

        [JsonPropertyOrder(6)]
        public Color TextColor { get; set; }

        [JsonPropertyOrder(7)]
        public Vector4 Margins { get; set; }

        [JsonPropertyOrder(8)]
        public eFontAsset FontAsset { get; set; }

        [JsonPropertyOrder(9)]
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
