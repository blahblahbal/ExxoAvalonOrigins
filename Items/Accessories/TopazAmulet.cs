using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories;

class TopazAmulet : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Topaz Amulet");
        Tooltip.SetDefault("5% increased melee damage");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.rare = ItemRarityID.Blue;
        Item.width = dims.Width;
        Item.accessory = true;
        Item.value = Item.sellPrice(0, 0, 30);
        Item.height = dims.Height;
    }

    public override void UpdateAccessory(Player player, bool hideVisual)
    {
        player.GetDamage(DamageClass.Melee) += 0.05f;
    }

    public override void AddRecipes()
    {
        CreateRecipe(1).AddIngredient(ItemID.Topaz, 12).AddIngredient(ItemID.Chain).AddTile(TileID.Anvils).Register();
    }
}