using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Magic
{
    internal class BlahStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blah Staff");
            Tooltip.SetDefault("Summons blah meteors that rain from the sky\nMeteors rain stars that explode into fire");
            Item.staff[item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.staff[item.type] = true;
            Rectangle dims = this.GetDims();
            item.useStyle = 5;
            item.autoReuse = true;
            item.magic = true;
            item.damage = 278;
            item.mana = 30;
            item.noMelee = true;
            item.rare = ItemRarityID.Purple;
            item.width = dims.Width;
            item.knockBack = 16f;
            item.useTime = 15;
            item.value = Item.sellPrice(2);
            item.useAnimation = 15;
            item.height = dims.Height;
            item.shootSpeed = 20f;
            item.UseSound = SoundID.Item88;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Placeable.Tile.Phantoplasm>(), 45);
            recipe.AddIngredient(ModContent.ItemType<Placeable.Bar.SuperhardmodeBar>(), 40);
            recipe.AddIngredient(ModContent.ItemType<Material.SoulofTorture>(), 45);
            recipe.AddIngredient(ItemID.LunarFlareBook);
            recipe.AddIngredient(ModContent.ItemType<SolariumStaff>());
            recipe.AddIngredient(ModContent.ItemType<OpalStaff>());
            recipe.AddIngredient(ModContent.ItemType<OnyxStaff>());
            recipe.AddTile(ModContent.TileType<Tiles.SolariumAnvil>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override bool UseItem(Player player)
        {
            if (player.whoAmI == Main.myPlayer)
            {
                for (int num9 = 0; num9 < 1; num9++)
                {
                    Vector2 vector = new Vector2(player.position.X + player.width * 0.5f + Main.rand.Next(201) * -player.direction + (Main.mouseX + Main.screenPosition.X - player.position.X), player.MountedCenter.Y - 600f);
                    vector.X = (vector.X + player.Center.X) / 2f + (float)Main.rand.Next(-200, 201);
                    vector.Y -= 100 * num9;
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
                    int p = Projectile.NewProjectile(vector.X, vector.Y, vector3.X, vector3.Y, ModContent.ProjectileType<Projectiles.BlahMeteor>(), (int)(item.damage * player.magicDamage), item.knockBack, player.whoAmI, 0f, ai2);
                    Main.projectile[p].owner = player.whoAmI;
                }
            }
            return true;
        }
    }
}
