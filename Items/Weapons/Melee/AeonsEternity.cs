﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Melee
{
    public class AeonsEternity : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Aeon's Eternity");
        }
        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.damage = 36;
            item.scale = 1.1f;
            item.melee = true;
            item.autoReuse = true;
            item.useTurn = true;
            item.rare = ItemRarityID.Pink;
            item.width = dims.Width;
            item.height = dims.Height;
            item.useTime = 30;
            item.useAnimation = 20;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.knockBack = 5f;
            item.shoot = ModContent.ProjectileType<Projectiles.Melee.AeonBeam2>();
            item.shootSpeed = 9f;
            item.UseSound = SoundID.Item1;
            item.value = Item.sellPrice(0, 1, 0, 0);
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.IceBlade);
            recipe.AddIngredient(ItemID.Starfury);
            recipe.AddIngredient(ModContent.ItemType<DesertLongSword>());
            recipe.AddIngredient(ModContent.ItemType<RhodiumGreatsword>());
            recipe.AddIngredient(ModContent.ItemType<MinersSword>());
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.IceBlade);
            recipe.AddIngredient(ItemID.Starfury);
            recipe.AddIngredient(ModContent.ItemType<DesertLongSword>());
            recipe.AddIngredient(ModContent.ItemType<OsmiumGreatsword>());
            recipe.AddIngredient(ModContent.ItemType<MinersSword>());
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.IceBlade);
            recipe.AddIngredient(ItemID.Starfury);
            recipe.AddIngredient(ModContent.ItemType<DesertLongSword>());
            recipe.AddIngredient(ModContent.ItemType<IridiumGreatsword>());
            recipe.AddIngredient(ModContent.ItemType<MinersSword>());
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.Next(5) == 0)
            {
                int num208 = Main.rand.Next(3);
                if (num208 == 0)
                {
                    num208 = 15;
                }
                else if (num208 == 1)
                {
                    num208 = 57;
                }
                else if (num208 == 2)
                {
                    num208 = 58;
                }
                int num209 = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, num208);
                Dust dust = Main.dust[num209];
                dust.velocity *= 0.2f;
                dust.scale = 1.3f;
            }
        }
    }
}
