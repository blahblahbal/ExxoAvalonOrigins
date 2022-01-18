﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.AdvancedPotions
{
    class AdvHeartreachPotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Heartreach Elixir");
            Tooltip.SetDefault("Increases pickup range for life hearts");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Items/AdvancedPotions/AdvHeartreachPotion");
            item.buffType = ModContent.BuffType<Buffs.AdvancedBuffs.AdvHeartreach>();
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
            item.buffTime = 28800 * 2;
        }
    }
}