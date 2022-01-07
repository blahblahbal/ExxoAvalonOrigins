using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    class BronzeChainmail : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bronze Chainmail");
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Placeable.Bar.BronzeBar>(), 20);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.defense = 2;
            item.width = dims.Width;
            item.value = Item.sellPrice(0, 0, 0, 50);
            item.height = dims.Height;
        }
    }
}
