using ExxoAvalonOrigins.Backgrounds;
using ExxoAvalonOrigins.Players;
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
            return musicMod != null ? MusicLoader.GetMusicSlot(musicMod, "Sounds/Music/Contagion") : MusicID.Crimson;
        }
    }

    public override ModSurfaceBackgroundStyle SurfaceBackgroundStyle
    {
        get
        {
            if (Main.LocalPlayer.ZoneDesert)
            {
                return new ContagionSurfaceDesertBackground();
            }

            return new ContagionSurfaceBackground();
        }
    }

    public override ModUndergroundBackgroundStyle UndergroundBackgroundStyle
    {
        get
        {
            if (Main.LocalPlayer.ZoneSnow)
            {
                return new ContagionUndergroundSnowBackground();
            }

            return new ContagionUndergroundBackground();
        }
    }

    public override bool IsBiomeActive(Player player)
    {
        return player.GetModPlayer<ExxoBiomePlayer>().ZoneContagion;
    }
}
