using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Biomes;

public class Tropics : ModBiome
{
    public override SceneEffectPriority Priority => SceneEffectPriority.BiomeMedium;
    public override int Music
    {
        get
        {
            Mod musicMod = ModLoader.GetMod("AvalonMusic");
            if (musicMod != null)
            {
                return MusicLoader.GetMusicSlot(musicMod, "Sounds/Music/Tropics");
            }
            return MusicID.Jungle;
        }
    }
    public override bool IsBiomeActive(Player player)
    {
        player.Avalon().ZoneTropics = ExxoAvalonOriginsWorld.tropicTiles > 50;
        return player.Avalon().ZoneTropics;
    }
}

