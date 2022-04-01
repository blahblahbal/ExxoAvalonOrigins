using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor
{
    [AutoloadEquip(EquipType.Legs)]
    class NickelGreaves : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nickel Greaves");
        }
        public override void AddRecipes()
        {
            CreateRecipe(1).AddIngredient(ModContent.ItemType<Placeable.Bar.NickelBar>(), 20).AddTile(TileID.Anvils).Register();
        }
        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.defense = 3;
            Item.width = dims.Width;
            Item.value = Item.sellPrice(0, 0, 10);
            Item.height = dims.Height;
        }
    }
}
