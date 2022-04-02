using ExxoAvalonOrigins.Backgrounds;
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
            return musicMod != null ? MusicLoader.GetMusicSlot(musicMod, "Sounds/Music/Tropics") : MusicID.Jungle;
        }
    }

    public override ModSurfaceBackgroundStyle SurfaceBackgroundStyle => new TropicsSurfaceBackground();

    public override bool IsBiomeActive(Player player)
    {
        player.Avalon().ZoneTropics = ExxoAvalonOriginsWorld.tropicTiles > 50;
        return player.Avalon().ZoneTropics;
    }
}
