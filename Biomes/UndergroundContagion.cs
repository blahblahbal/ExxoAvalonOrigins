using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Biomes;

public class UndergroundContagion : ModBiome
{
    public override SceneEffectPriority Priority => SceneEffectPriority.BiomeHigh;
    public override int Music
    {
        get
        {
            Mod musicMod = ModLoader.GetMod("AvalonMusic");
            if (musicMod != null)
            {
                return MusicLoader.GetMusicSlot(musicMod, "Sounds/Music/UndergroundContagion");
            }
            return MusicID.UndergroundCrimson;
        }
    }
    public override bool IsBiomeActive(Player player)
    {
        return player.Avalon().ZoneContagion && player.position.Y > (Main.worldSurface * 16.0) + (Main.screenHeight / 2);
    }
}

