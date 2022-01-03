using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Material
{
    public class ImperviousKey : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Impervious Key");
            Tooltip.SetDefault("Opens the Hellcastle doors");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.maxStack = 999;
            item.width = dims.Width;
            item.value = 0;
            item.height = dims.Height;
            item.rare = ItemRarityID.Cyan;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TempleKey, 2);
            recipe.AddIngredient(ItemID.Ectoplasm, 10);
            recipe.AddIngredient(ModContent.ItemType<EarthStone>());
            recipe.AddIngredient(ItemID.LunarBar, 5);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 2);
            recipe.AddRecipe();
        }
    }
}
