using ExtraGeoCustomization.Data;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ExtraGeoCustomisation.Utils
{
    //Code provided by ChatGPT (because i don't know how to do this shit)
    public class BaseCustomisationConverter : JsonConverter<BaseCustomisation>
    {
        public override BaseCustomisation Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            // Read the full JSON object
            using var jsonDoc = JsonDocument.ParseValue(ref reader);
            var root = jsonDoc.RootElement;

            if (!root.TryGetProperty("Type", out JsonElement typeElement))
                throw new JsonException("Missing 'Type' discriminator");

            // Map the Type value to actual class type
            var type = (eCustomisationType)typeElement.GetInt32();

            BaseCustomisation result = type switch
            {
                eCustomisationType.TextObject => JsonSerializer.Deserialize<TextObject>(root.GetRawText(), options),
                eCustomisationType.DamageArea => JsonSerializer.Deserialize<DamageableArea>(root.GetRawText(), options),
                eCustomisationType.ShuttleBox => JsonSerializer.Deserialize<ShuttleBox>(root.GetRawText(), options),
                eCustomisationType.AreaRenaming => JsonSerializer.Deserialize<AreaRenaming>(root.GetRawText(), options),
                eCustomisationType.BigPickupSpawnPoint => JsonSerializer.Deserialize<BigPickupSpawnPoint>(root.GetRawText(), options),
                eCustomisationType.SmallPickupSpawnPoint => JsonSerializer.Deserialize<SmallPickupSpawnPoint>(root.GetRawText(), options),
                eCustomisationType.PhysicsObject => JsonSerializer.Deserialize<PhysicsObject>(root.GetRawText(), options),
                eCustomisationType.Interactableobject => JsonSerializer.Deserialize<InteractableObject>(root.GetRawText(), options),
                eCustomisationType.EnemySpawnpoint => JsonSerializer.Deserialize<EnemySpawnpoint>(root.GetRawText(), options),
                eCustomisationType.CustomFogArea => JsonSerializer.Deserialize<CustomFogArea>(root.GetRawText(), options),
                eCustomisationType.CustomTriggerBox => JsonSerializer.Deserialize<CustomTriggerBox>(root.GetRawText(), options),
                eCustomisationType.CustomGenerator => JsonSerializer.Deserialize<CustomGenerator>(root.GetRawText(), options),
                _ => throw new JsonException($"Unknown customisation type: {type}")
            };

            return result;
        }

        public override void Write(Utf8JsonWriter writer, BaseCustomisation value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, (object)value, value.GetType(), options);
        }
    }
}
