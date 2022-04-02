using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Biomes;

public class Contagion : ModBiome
{
    public override SceneEffectPriority Priority => SceneEffectPriority.BiomeHigh;
    public override int Music
    {
        get
        {
            Mod musicMod = ModLoader.GetMod("AvalonMusic");
            if (musicMod != null)
            {
                return MusicLoader.GetMusicSlot(musicMod, "Sounds/Music/Contagion");
            }
            return MusicID.Crimson;
        }
    }
    public override bool IsBiomeActive(Player player)
    {
        player.Avalon().ZoneContagion = ExxoAvalonOriginsWorld.ickyTiles > 200;
        return player.Avalon().ZoneContagion;
    }
}

