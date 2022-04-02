using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Biomes;

public class CaesiumBlastplains : ModBiome
{
    //public override SceneEffectPriority Priority => SceneEffectPriority.Environment;
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
        player.Avalon().ZoneCaesium = ExxoAvalonOriginsWorld.caesiumTiles > 200 && player.position.Y / 16 > Main.maxTilesY - 200;
        return player.Avalon().ZoneCaesium;
    }
}

