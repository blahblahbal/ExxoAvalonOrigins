using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Magic
{
    class SpiritbeamFork : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spiritbeam Fork");
            Item.staff[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.DamageType = DamageClass.Magic;
            Item.damage = 60;
            Item.autoReuse = true;
            Item.shootSpeed = 6f;
            Item.mana = 15;
            Item.rare = ItemRarityID.Cyan;
            Item.noMelee = true;
            Item.width = dims.Width;
            Item.useTime = 19;
            Item.knockBack = 4.25f;
            Item.shoot = ProjectileID.ShadowBeamFriendly;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.value = Item.sellPrice(0, 30, 0, 0);
            Item.useAnimation = 19;
            Item.height = dims.Height;
            Item.UseSound = SoundID.Item43;
        }
        public override void AddRecipes()
        {
            CreateRecipe(1).AddIngredient(ItemID.InfernoFork).AddIngredient(ItemID.SpectreStaff).AddIngredient(ItemID.ShadowbeamStaff).AddIngredient(ModContent.ItemType<Material.SoulofBlight>(), 20).AddTile(ModContent.TileType<Tiles.SolariumAnvil>()).Register();
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage,
            ref float knockBack)
        {
            for (int num172 = 0; num172 < 3; num172++)
            {
                float num173 = speedX;
                float num174 = speedY;
                num173 += (float)Main.rand.Next(-30, 31) * 0.05f;
                num174 += (float)Main.rand.Next(-30, 31) * 0.05f;
                switch (num172)
                {
                    case 0:
                        Projectile.NewProjectile(position.X, position.Y, num173, num174, ProjectileID.InfernoFriendlyBolt, damage, knockBack, player.whoAmI, 0f, 0f);
                        break;
                    case 1:
                        Projectile.NewProjectile(position.X, position.Y, num173, num174, ProjectileID.LostSoulFriendly, damage, knockBack, player.whoAmI, 0f, 0f);
                        break;
                    case 2:
                        Projectile.NewProjectile(position.X, position.Y, num173, num174, ProjectileID.ShadowBeamFriendly, damage, knockBack, player.whoAmI, 0f, 0f);
                        break;
                }
            }

            return false;
        }
    }
}
