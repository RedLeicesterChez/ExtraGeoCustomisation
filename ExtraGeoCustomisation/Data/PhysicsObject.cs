using System.Text.Json.Serialization;

namespace ExtraGeoCustomisation.Data
{
    [System.Serializable]
    public class PhysicsObject : BaseCustomisation
    {
        [JsonPropertyOrder(4)]
        public float Mass { get; set; }

        [JsonPropertyOrder(5)]
        public float Drag { get; set; }

        [JsonPropertyOrder(6)]
        public float AngularDrag { get; set; }

        [JsonPropertyOrder(7)]
        public bool UseGravity { get; set; }

        [JsonPropertyOrder(8)]
        public RigidBodyConstraints Constraints { get; set; }

        [JsonPropertyOrder(9)]
        public eInterpolation Interpolation { get; set; }

        [JsonPropertyOrder(10)]
        public eCollisionDetection CollisionDetection { get; set; }
    }

    [System.Serializable]
    public class RigidBodyConstraints
    {
        public bool FreezePosX { get; set; }
        public bool FreezePosY { get; set; }
        public bool FreezePosZ { get; set; }
        public bool FreezeRotX { get; set; }
        public bool FreezeRotY { get; set; }
        public bool FreezeRotZ { get; set; }
    }

    [System.Serializable]
    public enum eInterpolation
    {
        None = 0,
        Interpolate = 1,
        Extrapolate = 2,
    }

    [System.Serializable]
    public enum eCollisionDetection
    {
        Discrete = 0,
        Continuous = 1,
        ContinuousDynamic = 2,
        ContinuousSpeculative = 3,
    }
}
