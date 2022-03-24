﻿using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Magic
{
    public class Starfall : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Starfall");
            Tooltip.SetDefault("'The power of the stars consumes your mana'");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.magic = true;
            item.damage = 1000;
            item.mana = 400;
            item.noMelee = true;
            item.rare = ItemRarityID.Yellow;
            item.width = dims.Width;
            item.knockBack = 16f;
            item.useTime = 35;
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.value = Item.sellPrice(0, 40, 0, 0);
            item.useAnimation = 35;
            item.height = dims.Height;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Material.BrokenVigilanteTome>());
            recipe.AddIngredient(ItemID.FallenStar, 200);
            recipe.AddIngredient(ItemID.MeteoriteBar, 150);
            recipe.AddIngredient(ModContent.ItemType<Placeable.Bar.OblivionBar>(), 17);
            recipe.AddIngredient(ModContent.ItemType<Material.SoulofDelight>(), 35);
            recipe.AddTile(ModContent.TileType<Tiles.SolariumAnvil>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override bool UseItem(Player player)
        {
            //float x = Main.mouseX + Main.screenPosition.X;
            //float y = Main.mouseY + Main.screenPosition.Y - Main.rand.Next(500, 800);
            //float speedX = 0;
            //float speedY = 14.9f;
            //int type = ProjectileID.FallingStar;
            //int damage = (int)(player.inventory[player.selectedItem].damage * player.magicDamage);
            //float knockback = 16f;
            //int owner = player.whoAmI;
            //int projID = Projectile.NewProjectile(x, y, speedX, speedY, type, damage, knockback, owner);
            //return true;

            if (player.whoAmI == Main.myPlayer)
            {
                for (int times = 0; times < 3; times++)
                {
                    Vector2 vector = new Vector2(player.position.X + player.width * 0.5f + Main.rand.Next(201) * -player.direction + (Main.mouseX + Main.screenPosition.X - player.position.X), player.MountedCenter.Y - 600f);
                    vector.X = (vector.X + player.Center.X) / 2f + (float)Main.rand.Next(-200, 201);
                    vector.Y -= 100 * times;
                    float num311 = Main.mouseX + Main.screenPosition.X - vector.X;
                    float num312 = Main.mouseY + Main.screenPosition.Y - vector.Y;
                    float ai2 = num312 + vector.Y;
                    if (num312 < 0f)
                    {
                        num312 *= -1f;
                    }
                    if (num312 < 20f)
                    {
                        num312 = 20f;
                    }
                    float num313 = (float)Math.Sqrt(num311 * num311 + num312 * num312);
                    num313 = item.shootSpeed / num313;
                    num311 *= num313;
                    num312 *= num313;
                    Vector2 vector3 = new Vector2(num311, num312) / 2f;
                    int p = Projectile.NewProjectile(vector.X, vector.Y, vector3.X, vector3.Y, ProjectileID.FallingStar, (int)(item.damage * player.magicDamage), item.knockBack, player.whoAmI, 0f, ai2);
                    Main.projectile[p].owner = player.whoAmI;
                }
            }
            return true;
        }
    }
}
