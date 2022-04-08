using ExxoAvalonOrigins.Systems;
using ExxoAvalonOrigins.Walls;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Players;

partial class ExxoModPlayer
{
    public bool ZoneContagion { get; private set; }
    public bool ZoneCaesium { get; private set; }
    public bool ZoneCrystal { get; private set; }
    public bool ZoneDarkMatter { get; private set; }
    public bool ZoneHellcastle { get; private set; }
    public bool ZoneSkyFortress { get; private set; }
    public bool ZoneTropics { get; private set; }
    public bool ZoneTuhrtlOutpost { get; private set; }
    public bool ZoneNearHellcastle { get; private set; }
    public bool ZoneComet { get; private set; }

    public void UpdateZones(BiomeTileCounts biomeTileCounts)
    {
        Point tileCoordinates = Player.Center.ToTileCoordinates();
        ushort wallType = Main.tile[tileCoordinates.X, tileCoordinates.Y].WallType;

        ZoneContagion = biomeTileCounts.ContagionTiles > 200;
        ZoneCaesium = biomeTileCounts.CaesiumTiles > 200 && Player.ZoneUnderworldHeight;
        ZoneCrystal = biomeTileCounts.CrystalTiles > 100;
        ZoneDarkMatter = biomeTileCounts.DarkTiles > 300;
        ZoneHellcastle = biomeTileCounts.HellCastleTiles > 350 &&
                         wallType == ModContent.WallType<ImperviousBrickWallUnsafe>() && Player.ZoneUnderworldHeight;
        ZoneSkyFortress = biomeTileCounts.SkyFortressTiles > 50 && Player.ZoneSkyHeight;
        ZoneTropics = biomeTileCounts.TropicsTiles > 50;
        ZoneTuhrtlOutpost = ZoneTropics && wallType == ModContent.WallType<TuhrtlBrickWallUnsafe>() &&
                            Player.ZoneRockLayerHeight;
    }
}
