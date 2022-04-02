using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories;

class QuackinaBalloon : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Quack in a Balloon");
        Tooltip.SetDefault("Allows the holder to double jump\nIncreases jump height\n'May annoy others'");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.rare = ItemRarityID.Purple;
        Item.width = dims.Width;
        Item.accessory = true;
        Item.value = Item.sellPrice(0, 1, 0, 0);
        Item.height = dims.Height;
    }
    public override void UpdateAccessory(Player player, bool hideVisual)
    {
        player.Avalon().quackJump = true;
        player.jumpBoost = true;
    }
    public override void AddRecipes()
    {
        CreateRecipe(1).AddIngredient(ModContent.ItemType<QuackinaBottle>()).AddIngredient(ItemID.ShinyRedBalloon).AddTile(TileID.TinkerersWorkbench).Register();
    }
}