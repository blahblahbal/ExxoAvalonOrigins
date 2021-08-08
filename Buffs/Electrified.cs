using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Buffs
{
    public class Electrified : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Electrified");
            Description.SetDefault("Losing more life when moving");
        }
        public override void Update(Player player, ref int buffIndex)
        {
            if (player.lifeRegen > 0)
            {
                player.lifeRegen = 0;
            }
            player.lifeRegenTime = 0;
            int minus = ((player.GetModPlayer<ExxoAvalonOriginsModPlayer>().frontReflect && player.GetModPlayer<ExxoAvalonOriginsModPlayer>().HasItemInArmor(ModContent.ItemType<Items.DurataniumShield>())) ? 4 : (player.GetModPlayer<ExxoAvalonOriginsModPlayer>().frontReflect ? 6 : 8));
            int minus2 = ((player.GetModPlayer<ExxoAvalonOriginsModPlayer>().frontReflect && player.GetModPlayer<ExxoAvalonOriginsModPlayer>().HasItemInArmor(ModContent.ItemType<Items.DurataniumOmegaShield>())) ? 16 : (player.GetModPlayer<ExxoAvalonOriginsModPlayer>().frontReflect ? 24 : 32));
            player.lifeRegen -= minus;
            if (player.velocity.X != 0)
            {
                player.lifeRegen -= minus2;
            }
        }
        public override void Update(NPC npc, ref int buffIndex)
        {
            if (npc.lifeRegen > 0)
            {
                npc.lifeRegen = 0;
            }
            npc.lifeRegen -= 8;
            if (npc.velocity.X != 0)
            {
                npc.lifeRegen -= 32;
            }
        }
    }
}
