using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExxoAvalonOrigins.Items.Accessories;
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
            Main.debuff[Type] = true;
            canBeCleared = false;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            if (player.lifeRegen > 0)
            {
                player.lifeRegen = 0;
            }
            player.lifeRegenTime = 0;
            int minus = ((player.GetModPlayer<ExxoAvalonOriginsModPlayer>().duraShield && player.GetModPlayer<ExxoAvalonOriginsModPlayer>().HasItemInArmor(ModContent.ItemType<DurataniumShield>())) ? 4 : (player.GetModPlayer<ExxoAvalonOriginsModPlayer>().duraShield ? 6 : 8));
            int minus2 = ((player.GetModPlayer<ExxoAvalonOriginsModPlayer>().duraShield && player.GetModPlayer<ExxoAvalonOriginsModPlayer>().HasItemInArmor(ModContent.ItemType<DurataniumOmegaShield>())) ? 16 : (player.GetModPlayer<ExxoAvalonOriginsModPlayer>().duraShield ? 24 : 32));
            player.lifeRegen -= minus;
            if (player.velocity.X != 0)
            {
                player.lifeRegen -= minus2;
            }
        }
    }
}
