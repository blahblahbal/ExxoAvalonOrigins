using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Buffs
{
    public class Infected : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Infected");
            Description.SetDefault("Losing life");
            Main.debuff[Type] = true;
        }

        public override void Update(Player player, ref int k)
        {
            player.GetModPlayer<ExxoAvalonOriginsModPlayer>().infectTimer++;
            if (player.GetModPlayer<ExxoAvalonOriginsModPlayer>().infectTimer % 60 == 0 && player.GetModPlayer<ExxoAvalonOriginsModPlayer>().infectTimer != 0)
            {
                if (player.GetModPlayer<ExxoAvalonOriginsModPlayer>().infectDmg < 16)
                {
                    player.GetModPlayer<ExxoAvalonOriginsModPlayer>().infectDmg *= 2;
                }
                else
                {
                    player.GetModPlayer<ExxoAvalonOriginsModPlayer>().infectDmg = 16;
                }
                player.Hurt(PlayerDeathReason.ByCustomReason(" was infected."), player.GetModPlayer<ExxoAvalonOriginsModPlayer>().infectDmg, 0, false, false, false);
            }
        }
    }
}
