using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor
{
    [AutoloadEquip(EquipType.Legs)]
    class ZincGreaves : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Zinc Greaves");
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Placeable.Bar.ZincBar>(), 20);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.defense = 4;
            item.width = dims.Width;
            item.value = Item.sellPrice(0, 0, 1, 75);
            item.height = dims.Height;
        }
    }
}
