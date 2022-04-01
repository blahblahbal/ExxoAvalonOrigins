using System;
using ExxoAvalonOrigins.Items.Weapons.Magic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Blah
{
    public class BlahStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blah Staff");
            Tooltip.SetDefault("Summons blah meteors that rain from the sky\nMeteors rain stars that explode into fire");
            Item.staff[Item.type] = true;
        }

        public override void SetDefaults()
        {
            
            Item.staff[Item.type] = true;
            Rectangle dims = this.GetDims();
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.autoReuse = true;
            Item.DamageType = DamageClass.Magic;
            Item.damage = 278;
            Item.mana = 19;
            Item.noMelee = true;
            Item.rare = ItemRarityID.Purple;
            Item.width = dims.Width;
            Item.knockBack = 16f;
            Item.useTime = 15;
            Item.value = Item.sellPrice(2);
            Item.useAnimation = 15;
            Item.height = dims.Height;
            Item.shootSpeed = 20f;
            Item.UseSound = SoundID.Item88;
        }
        public override void AddRecipes()
        {
            CreateRecipe(1).AddIngredient(ModContent.ItemType<Placeable.Tile.Phantoplasm>(), 45).AddIngredient(ModContent.ItemType<Placeable.Bar.SuperhardmodeBar>(), 40).AddIngredient(ModContent.ItemType<Material.SoulofTorture>(), 45).AddIngredient(ItemID.LunarFlareBook).AddIngredient(ModContent.ItemType<SolariumStaff>()).AddIngredient(ModContent.ItemType<OpalStaff>()).AddIngredient(ModContent.ItemType<OnyxStaff>()).AddTile(ModContent.TileType<Tiles.SolariumAnvil>()).Register();
        }
        public override bool? UseItem(Player player)
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
