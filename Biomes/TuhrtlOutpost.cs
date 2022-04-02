using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Biomes;

public class TuhrtlOutpost : ModBiome
{
    public override SceneEffectPriority Priority => SceneEffectPriority.BiomeHigh;
    public override int Music
    {
        get
        {
            Mod musicMod = ModLoader.GetMod("AvalonMusic");
            if (musicMod != null)
            {
                return MusicLoader.GetMusicSlot(musicMod, "Sounds/Music/TuhrtlOutpost");
            }
            return MusicID.Temple;
        }
    }
    public override bool IsBiomeActive(Player player)
    {
        Point tileC = player.position.ToTileCoordinates();
        player.Avalon().ZoneOutpost = ExxoAvalonOriginsWorld.tropicTiles > 50 && Main.tile[tileC.X, tileC.Y].WallType == ModContent.WallType<Walls.TuhrtlBrickWallUnsafe>() && player.ZoneRockLayerHeight;
        return player.Avalon().ZoneOutpost;
    }
}

