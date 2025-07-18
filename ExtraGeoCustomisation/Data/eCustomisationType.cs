namespace ExtraGeoCustomization.Data
{
    [System.Serializable]
    public enum eCustomisationType
    {
        none = 0,
        TextObject = 1, //TMP object
        DamageArea = 2, //Damages/heals or infects/disinfects players/enemies
        ShuttleBox = 3, //Shuttlebox with pickup or discard objects (with events)
        AreaRenaming = 4, //change the "zone" id of specific areas (terminals might be unaffected)
        BigPickupSpawnPoint = 5, //Spawn point for big pickups (can be forced)
        SmallPickupSpawnPoint = 6, //Spawn point for small pickups (can also be forced)
        PhysicsObject = 7, //an object with a RigidBody
        Interactableobject = 8, //An object that can be interacted with
        EnemySpawnpoint = 9, //A plugin spawnable enemy spawnpoint with custom spawn events
        CustomFogArea = 10, //Custom Fog Area (like in arbo A2)
        CustomTriggerBoxe = 11, //Custom trigger boxes with a variety of triggers
        CustomGenerator = 12, //Custom generators that you can insert or take cells out of
        TileEnemy = 13, //enemies built into the tile could be used to make a bossfight

        CustomChainedPuzzle = 15, //ChainedPuzzle independant from secdoors or terminals
        TerminalOverride = 16, //Override terminal data (like reactor commands and color)


        MovingPlatform = 40, //Moving platform with navmesh support (fucking kill me)

    }
}
