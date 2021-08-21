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
    class AdvWarmthPotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Warmth Elixir");
            Tooltip.SetDefault("Reduces damage from cold sources");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Items/AdvancedPotions/AdvWarmthPotion");
            item.buffType = ModContent.BuffType<Buffs.AdvancedBuffs.AdvWarmth>();
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
            item.buffTime = 108000;
        }
    }
}