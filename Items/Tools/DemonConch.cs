﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tools
{
    class DemonConch : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Demon Conch");
            Tooltip.SetDefault("If you listen closely, you can hear screams");
        }

        public override void SetDefaults()
        {
            item.rare = ItemRarityID.Orange;
            item.width = 24;
            item.useTime = 90;
            item.useTurn = true;
            item.value = Item.sellPrice(0, 1);
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.UseSound = SoundID.Item6;
            item.useAnimation = 90;
            item.height = 24;
        }
        public override void AddRecipes()
        {
            ModRecipe r = new ModRecipe(mod);
            r.AddIngredient(ItemID.MagicMirror);
            r.AddIngredient(ItemID.ShadowKey);
            r.AddIngredient(ItemID.LivingFireBlock, 50);
            r.AddTile(TileID.TinkerersWorkbench);
            r.SetResult(this);
            r.AddRecipe();
        }
        public override void HoldItem(Player player)
        {
            if (player.itemAnimation > 0 && player.whoAmI == Main.myPlayer)
            {
                if (Main.rand.Next(2) == 0)
                {
                    Dust.NewDust(player.position, player.width, player.height, DustID.MagicMirror, 0f, 0f, 150, default(Color), 1.1f);
                }
                if (player.itemTime == 0)
                {
                    player.itemTime = player.inventory[player.selectedItem].useTime;
                }
                else if (player.itemTime == player.inventory[player.selectedItem].useTime / 2)
                {
                    for (int num365 = 0; num365 < 70; num365++)
                    {
                        Dust.NewDust(player.position, player.width, player.height, DustID.MagicMirror, player.velocity.X * 0.5f, player.velocity.Y * 0.5f, 150, default(Color), 1.5f);
                    }
                    player.grappling[0] = -1;
                    player.grapCount = 0;
                    for (int num366 = 0; num366 < 1000; num366++)
                    {
                        if (Main.projectile[num366].active && Main.projectile[num366].owner == player.whoAmI && Main.projectile[num366].aiStyle == 7)
                        {
                            Main.projectile[num366].Kill();
                        }
                    }
                    player.Avalon().shadowTele = true;
                    player.Avalon().ShadowTP(5, player.whoAmI);
                    player.Avalon().shadowTele = false;
                    for (int num367 = 0; num367 < 70; num367++)
                    {
                        Dust.NewDust(player.position, player.width, player.height, DustID.MagicMirror, 0f, 0f, 150, default(Color), 1.5f);
                    }
                }
            }
        }
    }
}
