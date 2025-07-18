namespace ExtraGeoCustomization.Data
{
    [System.Serializable]
    public class PhysicsObject : BaseCustomisation
    {
        public float Mass { get; set; }
        public float Drag { get; set; }
        public float AngularDrag { get; set; }
        public bool UseGravity { get; set; }
        public RigidBodyConstraints Constraints { get; set; }
        public eInterpolation Interpolation { get; set; }
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
