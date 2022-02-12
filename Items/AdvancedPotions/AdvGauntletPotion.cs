﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.AdvancedPotions
{
    class AdvGauntletPotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gauntlet Elixir");
            Tooltip.SetDefault("-6 defense, +25% melee damage");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.GetDims("Items/AdvancedPotions/AdvGauntletPotion");
            item.buffType = ModContent.BuffType<Buffs.AdvancedBuffs.AdvGauntlet>();
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
            item.buffTime = 36000;
        }
    }
}