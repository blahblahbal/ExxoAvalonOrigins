using ExxoAvalonOrigins.Players;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Biomes;

public class HellCastle : ModBiome
{
    public override SceneEffectPriority Priority => SceneEffectPriority.Environment;

    public override int Music
    {
        get
        {
            Mod musicMod = ModLoader.GetMod("AvalonMusic");
            return musicMod != null ? MusicLoader.GetMusicSlot(musicMod, "Sounds/Music/Hellcastle") : MusicID.Dungeon;
        }
    }

    public override bool IsBiomeActive(Player player)
    {
        return player.GetModPlayer<ExxoBiomePlayer>().ZoneHellCastle;
    }
}
