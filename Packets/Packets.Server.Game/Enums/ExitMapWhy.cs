namespace Packets.Server.Game.Enums
{
    public enum ExitMapWhy : byte
    {
        None = 0x0,
        Teleport = 0x1,
        Immediately = 0x2,
        Levelup = 0x3,
        Cnt = 0x4,
    }
}
