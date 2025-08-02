namespace ExtraGeoCustomisation.Data
{
    [System.Serializable]
    public class GlobalGeoData
    {
        //I'm not 100% sure if this is a viable feature
        public string GeoPath { get; set; } = "segs";

        public BaseCustomisation[] Customisations { get; set; } = new BaseCustomisation[]
        {
            new TextObject
            {
                Type = eCustomisationType.TextObject,
                EventID = 1,
                StartEnabled = true,
                EventsOnActivate = [],
                EventsOnDeactivate = [],
                Text = "Warning",
                FontSize = 18,
                TextColor = new Color(1f, 0f, 0f, 1f), // Red
                Margins = new Vector4(5, 5, 5, 5),
                FontAsset = eFontAsset.FireMono,
                FontType = eFontType.Bold
            },
            new DamageableArea
            {
                Type = eCustomisationType.DamageArea,
                EventID = 2,
                StartEnabled = false,
                EventsOnActivate = [],
                EventsOnDeactivate = [],
                DamageType = eDamageType.Both,
                Damage = 10f,
                Infection = 5f,
                TargetType = eTargetType.Both,
                AreaType = eAreaType.Sphere,
                Scale = new Vector3(2, 2, 2),
                Position = new Vector3(0, 0, 0),
                CustomMeshPath = "Assets/Meshes/DamageArea.prefab"
            },
            new ShuttleBox
            {
                Type = eCustomisationType.ShuttleBox,
                EventID = 3,
                StartEnabled = true,
                EventsOnActivate = [],
                EventsOnDeactivate = [],
                Position = new Vector3(7, 0, 3),
                Rotation = new Vector3(0, 90, 0),
                InteractionSize = 1.5f,
                OnApproachTriggerSize = 3.0f,
                EventsOnPickup = [],
                EventsOnInsert = [],
                EventsOnApproach = []
            },
            new AreaRenaming
            {
                Type = eCustomisationType.AreaRenaming,
                EventID = 4,
                EventsOnActivate = [],
                EventsOnDeactivate = [],
                RenamedText = "Z1984",
                AreaIndexes = new int[] { 0, 1 },
                SeparateTerminalPings = true
            },
            new BigPickupSpawnPoint
            {
                Type = eCustomisationType.BigPickupSpawnPoint,
                EventID = 5,
                EventsOnActivate = [],
                EventsOnDeactivate = [],
                position = new Vector3(0, 0, 0),
                rotation = new Vector3(0, 0, 0),
                ForceSpawn = true,
                ItemID = 101
            },
            new SmallPickupSpawnPoint
            {
                Type = eCustomisationType.SmallPickupSpawnPoint,
                EventID = 6,
                EventsOnActivate = [],
                EventsOnDeactivate = [],
                Position = new Vector3(0, 1, 0),
                Rotation = new Vector3(0, 0, 0),
                ForceSpawn = false,
                ItemID = 404
            },
            new PhysicsObject
            {
                Type = eCustomisationType.PhysicsObject,
                EventID = 7,
                StartEnabled = true,
                EventsOnActivate = [],
                EventsOnDeactivate = [],
                Mass = 1.0f,
                Drag = 0.5f,
                AngularDrag = 0.05f,
                UseGravity = true,
                Constraints = new RigidBodyConstraints
                {
                    FreezePosX = false,
                    FreezePosY = true,
                    FreezePosZ = false,
                    FreezeRotX = false,
                    FreezeRotY = false,
                    FreezeRotZ = true
                },
                Interpolation = eInterpolation.Interpolate,
                CollisionDetection = eCollisionDetection.Continuous
            },
            new InteractableObject
            {
                Type = eCustomisationType.Interactableobject,
                EventID = 8,
                StartEnabled = true,
                EventsOnActivate = [],
                EventsOnDeactivate = [],
                Position = new Vector3(1, 1, 1),
                Rotation = new Vector3(0, 0, 0),
                InteractionRadius = 2.5f,
                OnApproachTriggerSize = 4f,
                InteractableObjectPath = "Assets/Prefabs/Button.prefab",
                EventsOnInteract = [],
                EventsOnApproach = []
            },
            new EnemySpawnpoint
            {
                Type = eCustomisationType.EnemySpawnpoint,
                EventID = 9,
                EventsOnActivate = [],
                EventsOnDeactivate = [],
                Position = new Vector3(15, 0, 5),
                Rotation = new Vector3(0, 180, 0),
                EventsOnEnemySpawn = []
            },
            new CustomFogArea
            {
                Type = eCustomisationType.CustomFogArea,
                EventID = 10,
                StartEnabled = true,
                EventsOnActivate = [],
                EventsOnDeactivate = [],
                CoverageType = eAreaType.Sphere,
                Position = new Vector3(10, 0, 5),
                Scale = new Vector3(1, 1, 1),
                CustomMeshPath = "Assets/CustomMeshes/Fog.obj",
                FogDataID = 200
            },
            new CustomTriggerBox
            {
                Type = eCustomisationType.CustomTriggerBox,
                EventID = 11,
                StartEnabled = true,
                EventsOnActivate = [],
                EventsOnDeactivate = [],
                CoverageType = eAreaType.Box,
                Position = new Vector3(2, 0, 2),
                Rotation = new Vector3(0, 0, 0),
                Vector3 = new Vector3(3, 1, 3),
                EventsOnEnter = [],
                EventsOnExit = [],
                EventsOnLookat = []
            },
            new CustomGenerator
            {
                Type = eCustomisationType.CustomGenerator,
                EventID = 12,
                EventsOnActivate = [],
                EventsOnDeactivate = [],
                Position = new Vector3(5, 0, 5),
                Rotation = new Vector3(0, 90, 0),
                BiDirectional = false,
                StartEmpty = true,
                ItemDataID = 300,
                EventsOnInsert = [],
                EventsOnRemove = []
            }
        };
    }
}
