﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories
{
    [AutoloadEquip(EquipType.Shoes, EquipType.Wings)]
    class InertiaBoots : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Inertia Boots");
            Tooltip.SetDefault("Allows flight and slow fall and the wearer can run incredibly fast\nThe wearer has a chance to dodge attacks and negates fall damage");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.GetDims("Items/Accessories/InertiaBoots");
            Item.defense = 4;
            Item.rare = ItemRarityID.Lime;
            Item.width = dims.Width;
            Item.value = Item.sellPrice(0, 16, 45, 0);
            Item.accessory = true;
            Item.height = dims.Height;
        }

        public override void AddRecipes()
        {
            CreateRecipe(1).AddRecipeGroup("ExxoAvalonOrigins:Wings").AddIngredient(ItemID.FrostsparkBoots).AddIngredient(ItemID.BlackBelt).AddIngredient(ItemID.LunarBar, 2).AddTile(TileID.TinkerersWorkbench).Register();
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.Avalon().noSticky = true;
            player.accRunSpeed = 10.29f;
            player.rocketBoots = 3;
            player.noFallDmg = true;
            player.blackBelt = true;
            player.iceSkate = true;
            player.wingTime = 1000;
            player.Avalon().inertiaBoots = true;
            //if (player.controlUp && player.controlJump)
            //{
            //    player.velocity.Y = player.velocity.Y - 0.3f * player.gravDir;
            //    if (player.gravDir == 1f)
            //    {
            //        if (player.velocity.Y > 0f)
            //        {
            //            player.velocity.Y = player.velocity.Y - 1f;
            //        }
            //        else if (player.velocity.Y > -Player.jumpSpeed)
            //        {
            //            player.velocity.Y = player.velocity.Y - 0.2f;
            //        }
            //        if (player.velocity.Y < -Player.jumpSpeed * 3f)
            //        {
            //            player.velocity.Y = -Player.jumpSpeed * 3f;
            //        }
            //    }
            //    else
            //    {
            //        if (player.velocity.Y < 0f)
            //        {
            //            player.velocity.Y = player.velocity.Y + 1f;
            //        }
            //        else if (player.velocity.Y < Player.jumpSpeed)
            //        {
            //            player.velocity.Y = player.velocity.Y + 0.2f;
            //        }
            //        if (player.velocity.Y > Player.jumpSpeed * 3f)
            //        {
            //            player.velocity.Y = Player.jumpSpeed * 3f;
            //        }
            //    }
            //}

            if (player.controlLeft)
            {
                if (player.velocity.X > -5f)
                {
                    player.velocity.X = player.velocity.X - 0.31f;
                }
                if (player.velocity.X < -5f && player.velocity.X > -10f)
                {
                    player.velocity.X = player.velocity.X - 0.29f;
                }
            }
            if (player.controlRight)
            {
                if (player.velocity.X < 5f)
                {
                    player.velocity.X = player.velocity.X + 0.31f;
                }
                if (player.velocity.X > 5f && player.velocity.X < 10f)
                {
                    player.velocity.X = player.velocity.X + 0.29f;
                }
            }
            if (player.velocity.X > 6f || player.velocity.X < -6f)
            {
                var newColor = default(Color);
                var num = Dust.NewDust(new Vector2(player.position.X, player.position.Y), player.width, player.height, DustID.Cloud, Main.rand.Next(-5, 5), Main.rand.Next(-5, 5), 100, newColor, 2f);
                Main.dust[num].noGravity = true;
            }
        }
    }
}
