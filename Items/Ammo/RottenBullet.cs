using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Ammo
{
    class RottenBullet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rotten Bullet");
            Tooltip.SetDefault("Slow speed, low range, but high damage and knockback");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.damage = 15;
            Item.shootSpeed = 1.5f;
            Item.ammo = AmmoID.Bullet;
            Item.DamageType = DamageClass.Ranged;
            Item.consumable = true;
            Item.rare = ItemRarityID.Orange;
            Item.width = dims.Width;
            Item.knockBack = 16f;
            Item.shoot = ModContent.ProjectileType<Projectiles.RottenBullet>();
            Item.value = 10;
            Item.maxStack = 2000;
            Item.height = dims.Height;
        }
        public override void AddRecipes()
        {
            CreateRecipe(25).AddIngredient(ItemID.MusketBall, 25).AddIngredient(ModContent.ItemType<Material.RottenEye>(), 5).AddIngredient(ItemID.CursedFlame).AddTile(TileID.MythrilAnvil).Register();
        }
    }
}
