﻿using Microsoft.Xna.Framework;
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
    class AdvCalmingPotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Advanced Calming Potion");
            Tooltip.SetDefault("Reduces enemy aggression and spawn rate");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Items/AdvancedPotions/AdvCalmingPotion");
            item.buffType = ModContent.BuffType<Buffs.AdvancedBuffs.AdvCalming>();
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
            item.buffTime = 36000;
        }
    }
}