using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Ranged
{
    class GleamingTwilight : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gleaming Twilight");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.damage = 90;
            Item.autoReuse = true;
            Item.useAmmo = AmmoID.Arrow;
            Item.shootSpeed = 11f;
            Item.DamageType = DamageClass.Ranged;
            Item.noMelee = true;
            Item.rare = ItemRarityID.Yellow;
            Item.width = dims.Width;
            Item.useTime = 15;
            Item.knockBack = 4.5f;
            Item.shoot = ProjectileID.WoodenArrowFriendly;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.value = 1000000;
            Item.useAnimation = 15;
            Item.height = dims.Height;
            Item.UseSound = SoundID.Item5;
        }
        public override void AddRecipes()
        {
            CreateRecipe(1).AddIngredient(ItemID.ChlorophyteShotbow).AddIngredient(ItemID.HallowedRepeater).AddIngredient(ModContent.ItemType<Material.SoulofBlight>(), 20).AddTile(ModContent.TileType<Tiles.SolariumAnvil>()).Register();
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage,
            ref float knockBack)
        {
            for (int num188 = 0; num188 < 5; num188++)
            {
                float num189 = speedX;
                float num190 = speedY;
                num189 += (float)Main.rand.Next(-40, 41) * 0.05f;
                num190 += (float)Main.rand.Next(-40, 41) * 0.05f;
                Projectile.NewProjectile(position.X, position.Y, num189, num190, type, damage, knockBack, player.whoAmI, 0f, 0f);
            }
            return false;
        }
    }
}
