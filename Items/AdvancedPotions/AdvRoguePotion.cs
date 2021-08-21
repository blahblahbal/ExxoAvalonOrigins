using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ExxoAvalonOrigins.Items.AdvancedPotions
{
    class AdvRoguePotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rogue Elixir");
            Tooltip.SetDefault("-5% ranged damage, 25% chance to not consume ammo");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Items/AdvancedPotions/AdvRoguePotion");
            item.buffType = ModContent.BuffType<Buffs.AdvancedBuffs.AdvRogue>();
            item.UseSound = SoundID.Item3;
            item.consumable = true;
            item.rare = 7;
            item.width = dims.Width;
            item.useTime = 15;
            item.useStyle = 2;
            item.maxStack = 100;
            item.value = Item.sellPrice(0, 0, 4, 0);
            item.useAnimation = 15;
            item.height = dims.Height;
            item.buffTime = 3600 * 9;
        }
    }
}