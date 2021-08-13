﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ExxoAvalonOrigins.Items
{
    class SpiritPoppy : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spirit Poppy");
            Tooltip.SetDefault("Permanently increases maximum mana by 20\nCan only be used when you have 200 or more mana\nMaxes at 400 mana");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Items/SpiritPoppy");
            item.UseSound = SoundID.Item4;
            item.consumable = true;
            item.rare = 8;
            item.width = dims.Width;
            item.useTime = 30;
            item.maxStack = 999;
            item.useStyle = 4;
            item.value = Item.sellPrice(0, 0, 50, 0);
            item.useAnimation = 30;
            item.height = dims.Height;
        }

        public override bool CanUseItem(Player player)
        {
            return player.statManaMax >= 200 && player.statManaMax < 400;
        }

        public override bool UseItem(Player player)
        {
            
            if (player.statManaMax == 200) player.GetModPlayer<ExxoAvalonOriginsModPlayer>().extraMana[0] = true;
            if (player.statManaMax == 220) player.GetModPlayer<ExxoAvalonOriginsModPlayer>().extraMana[1] = true;
            if (player.statManaMax == 240) player.GetModPlayer<ExxoAvalonOriginsModPlayer>().extraMana[2] = true;
            if (player.statManaMax == 260) player.GetModPlayer<ExxoAvalonOriginsModPlayer>().extraMana[3] = true;
            if (player.statManaMax == 280) player.GetModPlayer<ExxoAvalonOriginsModPlayer>().extraMana[4] = true;
            if (player.statManaMax == 300) player.GetModPlayer<ExxoAvalonOriginsModPlayer>().extraMana[5] = true;
            if (player.statManaMax == 320) player.GetModPlayer<ExxoAvalonOriginsModPlayer>().extraMana[6] = true;
            if (player.statManaMax == 340) player.GetModPlayer<ExxoAvalonOriginsModPlayer>().extraMana[7] = true;
            if (player.statManaMax == 360) player.GetModPlayer<ExxoAvalonOriginsModPlayer>().extraMana[8] = true;
            if (player.statManaMax == 380) player.GetModPlayer<ExxoAvalonOriginsModPlayer>().extraMana[9] = true;
            player.statManaMax += 20;
            //player.GetModPlayer<ExxoAvalonOriginsModPlayer>().statManaMax2 += 20;
            //player.GetModPlayer<ExxoAvalonOriginsModPlayer>().statManaMax3 += 20;
            //player.GetModPlayer<ExxoAvalonOriginsModPlayer>().statManaMax += 20;
            //player.GetModPlayer<ExxoAvalonOriginsModPlayer>().statMana += 20;
            //player.statManaMax += 20;
            //player.statMana += 20;
            //player.statManaMax2 += 20;
            return true;
        }
    }
}