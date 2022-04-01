using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Ammo
{
    class BloodyArrow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bloody Arrow");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.damage = 10;
            Item.shootSpeed = 3.4f;
            Item.ammo = AmmoID.Arrow;
            Item.DamageType = DamageClass.Ranged;
            Item.consumable = true;
            Item.rare = ItemRarityID.Blue;
            Item.width = dims.Width;
            Item.knockBack = 3f;
            Item.shoot = ModContent.ProjectileType<Projectiles.BloodyArrow>();
            Item.value = Item.sellPrice(0, 0, 0, 8);
            Item.maxStack = 2000;
            Item.height = dims.Height;
        }
        public override void AddRecipes()
        {
            CreateRecipe(5).AddIngredient(ItemID.WoodenArrow, 5).AddIngredient(ModContent.ItemType<Material.Patella>()).AddTile(TileID.Anvils).Register();
        }
    }
}
