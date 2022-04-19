namespace Server.Game.Models.Settings
{
    /// <summary>
    ///     Config for setting game server
    /// </summary>
    public class GameSetting
    {
        public short Id { get; set; }

        public string ServerIp { get; set; }
        public short ServerPort { get; set; }

        // Garbage settings
        public int GarbageItems { get; set; }
        public int GarbageUnits { get; set; }

        // Recovery characteristics hp mp
        public int RecoveryCharacteristics { get; set; }

        // Visible settings
        public int VisibleConnections { get; set; }
        public int VisibleItems { get; set; }
        public int VisibleUnits { get; set; }

        // Inventar settings
        public int ItemPickUpDistance { get; set; }

        public int SavePcsEverySeconds { get; set; }
    }
}