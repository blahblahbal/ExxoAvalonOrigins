using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Biomes;

public class Hellcastle : ModBiome
{
    public override SceneEffectPriority Priority => SceneEffectPriority.Environment;
    public override int Music
    {
        get
        {
            Mod musicMod = ModLoader.GetMod("AvalonMusic");
            if (musicMod != null)
            {
                return MusicLoader.GetMusicSlot(musicMod, "Sounds/Music/Hellcastle");
            }
            return MusicID.Dungeon;
        }
    }
    public override bool IsBiomeActive(Player player)
    {
        player.Avalon().ZoneHellcastle = false;
        if (ExxoAvalonOriginsWorld.hellcastleTiles >= 350)
        {
            int num = (int)player.position.X / 16;
            int num2 = (int)player.position.Y / 16;
            if (Main.tile[num, num2].WallType == ModContent.WallType<Walls.ImperviousBrickWallUnsafe>())
            {
                player.Avalon().ZoneHellcastle = true;
            }
        }
        return player.Avalon().ZoneHellcastle;
    }
}

