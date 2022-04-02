using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Biomes;

public class DarkMatter : ModBiome
{
    public override SceneEffectPriority Priority => SceneEffectPriority.Environment;
    public override int Music
    {
        get
        {
            Mod musicMod = ModLoader.GetMod("AvalonMusic");
            if (musicMod != null)
            {
                return MusicLoader.GetMusicSlot(musicMod, "Sounds/Music/DarkMatter");
            }
            return MusicID.Eclipse;
        }
    }
    public override bool IsBiomeActive(Player player)
    {
        player.Avalon().ZoneDarkMatter = ExxoAvalonOriginsWorld.darkTiles > 300;
        return player.Avalon().ZoneDarkMatter;
    }
}

