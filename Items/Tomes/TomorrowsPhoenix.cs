using ExxoAvalonOrigins.Items.Material;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tomes;

class TomorrowsPhoenix : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Tomorrow's Phoenix");
        Tooltip.SetDefault("Tome\n8% increased minion damage\n5% increased minion knockback");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.rare = ItemRarityID.Orange;
        Item.width = dims.Width;
        Item.value = Item.sellPrice(0, 0, 10);
        Item.height = dims.Height;
        Item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().tome = true;
    }

    public override void UpdateAccessory(Player player, bool hideVisual)
    {
        player.GetDamage(DamageClass.Summon) += 0.08f;
        player.minionKB += 0.05f;
    }

    public override void AddRecipes()
    {
        CreateRecipe(1).AddIngredient(ItemID.Gel, 100).AddIngredient(ModContent.ItemType<StrongVenom>(), 5).AddIngredient(ItemID.FallenStar, 20).AddIngredient(ModContent.ItemType<MysticalClaw>(), 4).AddIngredient(ModContent.ItemType<MysticalTomePage>(), 2).AddTile(ModContent.TileType<Tiles.TomeForge>()).Register();
    }
}