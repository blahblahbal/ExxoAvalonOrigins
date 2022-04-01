using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Material
{
    class MysteriousPage : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mysterious Page");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.rare = ItemRarityID.Green;
            Item.width = dims.Width;
            Item.value = Item.sellPrice(0, 0, 2, 0);
            Item.maxStack = 999;
            Item.height = dims.Height;
        }
        public override void AddRecipes()
        {
            CreateRecipe(2).AddIngredient(ItemID.Book, 10).AddTile(TileID.Bookcases).Register();
        }
    }
}
