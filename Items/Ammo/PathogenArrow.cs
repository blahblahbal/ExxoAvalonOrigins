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
            item.damage = 13;
            item.shootSpeed = 4f;
            item.ammo = AmmoID.Arrow;
            item.ranged = true;
            item.consumable = true;
            item.rare = ItemRarityID.Orange;
            item.width = dims.Width;
            item.knockBack = 4f;
            item.shoot = ModContent.ProjectileType<Projectiles.PathogenArrow>();
            item.value = Item.sellPrice(0, 0, 0, 50);
            item.maxStack = 2000;
            item.height = dims.Height;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.WoodenArrow, 35);
            recipe.AddIngredient(ModContent.ItemType<Material.Pathogen>());
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 35);
            recipe.AddRecipe();
        }
    }
}
