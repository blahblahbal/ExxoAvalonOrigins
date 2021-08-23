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
    class AdvRagePotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rage Elixir");
            Tooltip.SetDefault("Increases critical strike chance by 20%");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Items/AdvancedPotions/AdvRagePotion");
            item.buffType = ModContent.BuffType<Buffs.AdvancedBuffs.AdvRage>();
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
            item.buffTime = 28800;
        }
    }
}