using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor;

[AutoloadEquip(EquipType.Body)]
class NickelChainmail : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Nickel Chainmail");
    }
    public override void AddRecipes()
    {
        CreateRecipe(1).AddIngredient(ModContent.ItemType<Placeable.Bar.NickelBar>(), 25).AddTile(TileID.Anvils).Register();
    }
    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.defense = 3;
        Item.width = dims.Width;
        Item.value = Item.sellPrice(0, 0, 12);
        Item.height = dims.Height;
    }
}