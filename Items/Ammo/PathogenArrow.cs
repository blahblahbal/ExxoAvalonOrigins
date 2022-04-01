using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Ammo
{
    class PathogenArrow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Pathogen Arrow");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.damage = 13;
            Item.shootSpeed = 4f;
            Item.ammo = AmmoID.Arrow;
            Item.DamageType = DamageClass.Ranged;
            Item.consumable = true;
            Item.rare = ItemRarityID.Orange;
            Item.width = dims.Width;
            Item.knockBack = 4f;
            Item.shoot = ModContent.ProjectileType<Projectiles.PathogenArrow>();
            Item.value = Item.sellPrice(0, 0, 0, 50);
            Item.maxStack = 2000;
            Item.height = dims.Height;
        }
        public override void AddRecipes()
        {
            CreateRecipe(35).AddIngredient(ItemID.WoodenArrow, 35).AddIngredient(ModContent.ItemType<Material.Pathogen>()).AddTile(TileID.MythrilAnvil).Register();
        }
    }
}
