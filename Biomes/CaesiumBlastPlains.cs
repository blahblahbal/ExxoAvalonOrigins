using ExxoAvalonOrigins.Players;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Biomes;

public class CaesiumBlastPlains : ModBiome
{
    public override SceneEffectPriority Priority => SceneEffectPriority.Environment;

    //public override int Music
    //{
    //    get
    //    {
    //        Mod musicMod = ModLoader.GetMod("AvalonMusic");
    //        if (musicMod != null)
    //        {
    //            return MusicLoader.GetMusicSlot(musicMod, "Sounds/Music/CaesiumBlastplains");
    //        }
    //        return MusicID.Hell;
    //    }
    //}
    public override bool IsBiomeActive(Player player)
    {
        return player.GetModPlayer<ExxoBiomePlayer>().ZoneCaesium;
    }
}
