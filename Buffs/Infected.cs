using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Buffs;

public class Infected : ModBuff
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Infected");
        Description.SetDefault("Losing life");
        Main.debuff[Type] = true;
    }

    public override void Update(Player player, ref int k)
    {
        player.Avalon().infectTimer++;
        if (player.Avalon().infectTimer % 60 == 0 && player.Avalon().infectTimer != 0)
        {
            if (player.Avalon().infectDmg < 16)
            {
                player.Avalon().infectDmg *= 2;
            }
            else
            {
                player.Avalon().infectDmg = 16;
            }
            player.Hurt(PlayerDeathReason.ByCustomReason(" was infected."), player.Avalon().infectDmg, 0, false, false, false);
        }
    }
}