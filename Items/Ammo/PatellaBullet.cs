using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Ammo
{
    class PatellaBullet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Patella Bullet");
            Tooltip.SetDefault("Slow speed, low range, but high damage");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.damage = 15;
            Item.shootSpeed = 3f;
            Item.ammo = AmmoID.Bullet;
            Item.DamageType = DamageClass.Ranged;
            Item.consumable = true;
            Item.rare = ItemRarityID.Orange;
            Item.width = dims.Width;
            Item.knockBack = 3f;
            Item.shoot = ModContent.ProjectileType<Projectiles.PatellaBullet>();
            Item.value = 10;
            Item.maxStack = 2000;
            Item.height = dims.Height;
        }
        public override void AddRecipes()
        {
            CreateRecipe(25).AddIngredient(ItemID.MusketBall, 25).AddIngredient(ModContent.ItemType<Material.Patella>(), 5).AddIngredient(ItemID.Ichor).AddTile(TileID.MythrilAnvil).Register();
        }
    }
}
