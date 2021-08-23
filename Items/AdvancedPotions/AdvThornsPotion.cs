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
    class AdvThornsPotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Thorns Elixir");
            Tooltip.SetDefault("Attackers also take damage");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Items/AdvancedPotions/AdvThornsPotion");
            item.buffType = ModContent.BuffType<Buffs.AdvancedBuffs.AdvThorns>();
            item.UseSound = SoundID.Item3;
            item.consumable = true;
            item.rare = ItemRarityID.Lime;
            item.width = dims.Width;
            item.useTime = 15;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.maxStack = 100;
            item.value = Item.sellPrice(0, 0, 4, 0);
            item.useAnimation = 15;
            item.height = dims.Height;
            item.buffTime = 21600;
        }
    }
}