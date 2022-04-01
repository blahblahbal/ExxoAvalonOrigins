using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Ammo
{
    class ZincBullet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Zinc Bullet");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.shootSpeed = 3.75f;
            Item.damage = 11;
            Item.ammo = AmmoID.Bullet;
            Item.DamageType = DamageClass.Ranged;
            Item.consumable = true;
            Item.width = dims.Width;
            Item.knockBack = 3f;
            Item.shoot = ProjectileID.Bullet;
            Item.maxStack = 2000;
            Item.value = 15;
            Item.height = dims.Height;
        }
        public override void AddRecipes()
        {
            CreateRecipe(70).AddIngredient(ItemID.MusketBall, 70).AddIngredient(ModContent.ItemType<Placeable.Bar.ZincBar>(), 1).AddTile(TileID.Anvils).Register();
        }
    }
}
