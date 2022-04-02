using ExxoAvalonOrigins.Players;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Biomes;

public class SkyFortress : ModBiome
{
    public override SceneEffectPriority Priority => SceneEffectPriority.Environment;

    public override int Music
    {
        get
        {
            Mod musicMod = ModLoader.GetMod("AvalonMusic");
            if (musicMod != null)
            {
                return MusicID.Jungle; // MusicLoader.GetMusicSlot(musicMod, "Sounds/Music/SkyFortress");
            }

            return MusicID.Jungle;
        }
    }

    public override bool IsBiomeActive(Player player)
    {
        return player.GetModPlayer<ExxoBiomePlayer>().ZoneSkyFortress;
    }
}
