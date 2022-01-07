using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Material
{
    internal class AlienApparatus : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Alien Apparatus");
            Tooltip.SetDefault("Used for crafting the Eye of Oblivion");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.rare = ItemRarityID.Red;
            item.width = dims.Width;
            item.maxStack = 999;
            item.value = 0;
            item.height = dims.Height;
        }
        public override void AddRecipes()
        {
            ModRecipe r = new ModRecipe(mod);
            r.AddIngredient(ModContent.ItemType<Placeable.Tile.DragonScale>(), 3);
            r.AddIngredient(ModContent.ItemType<SoulofDelight>(), 5);
            r.AddIngredient(ModContent.ItemType<DarkMatterGel>(), 20);
            r.AddIngredient(ModContent.ItemType<AlienDevice>());
            r.AddTile(ModContent.TileType<Tiles.SolariumAnvil>());
            r.SetResult(this);
            r.AddRecipe();
        }
    }
}
