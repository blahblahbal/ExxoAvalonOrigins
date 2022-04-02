using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories;

class ZincWatch : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Zinc Watch");
        Tooltip.SetDefault("Tells the time");
    }

    public override void SetDefaults()
    {
        Item.CloneDefaults(ItemID.SilverWatch);
    }
    public override void AddRecipes()
    {
        CreateRecipe(1).AddIngredient(ModContent.ItemType<Placeable.Bar.ZincBar>(), 10).AddIngredient(ItemID.Chain).AddTile(TileID.WorkBenches).AddTile(TileID.Chairs).Register();
    }
    public override void UpdateAccessory(Player player, bool hideVisual)
    {
        if (player.accWatch < 2) player.accWatch = 2;
    }

    public override void UpdateInventory(Player player)
    {
        if (player.accWatch < 2) player.accWatch = 2;
    }
}