using ExxoAvalonOrigins.Items.Material;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories;

class ZirconAmulet : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Zircon Amulet");
        Tooltip.SetDefault("5% increased throwing damage");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.rare = ItemRarityID.Orange;
        Item.width = dims.Width;
        Item.accessory = true;
        Item.value = Item.sellPrice(0, 0, 70);
        Item.height = dims.Height;
    }

    public override void UpdateAccessory(Player player, bool hideVisual)
    {
        player.GetDamage(DamageClass.Throwing) += 0.05f;
    }

    public override void AddRecipes()
    {
        CreateRecipe(1).AddIngredient(ModContent.ItemType<Zircon>(), 12).AddIngredient(ItemID.Chain).AddTile(TileID.Anvils).Register();
    }
}