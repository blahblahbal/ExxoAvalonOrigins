using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Throw
{
    class Icicle : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Icicle");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.damage = 11;
            item.noUseGraphic = true;
            item.maxStack = 999;
            item.shootSpeed = 9f;
            item.ranged = true;
            item.consumable = true;
            item.noMelee = true;
            item.width = dims.Width;
            item.useTime = 15;
            item.knockBack = 3f;
            item.shoot = ModContent.ProjectileType<Projectiles.Icicle>();
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.value = 0;
            item.useAnimation = 15;
            item.height = dims.Height;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Material.FrostShard>());
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 10);
            recipe.AddRecipe();
        }
    }
}
