using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Vanity;

[AutoloadEquip(EquipType.Head)]
class BismuthCrown : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Bismuth Crown");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.vanity = true;
        Item.width = dims.Width;
        Item.value = 15000;
        Item.height = dims.Height;
    }

    public override void AddRecipes()
    {
        CreateRecipe(1).AddIngredient(ModContent.ItemType<Placeable.Bar.BismuthBar>(), 5).AddIngredient(ItemID.Ruby).AddTile(TileID.Anvils).Register();
    }
}