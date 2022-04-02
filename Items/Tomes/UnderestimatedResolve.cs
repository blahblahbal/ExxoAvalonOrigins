using ExxoAvalonOrigins.Items.Material;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tomes;

class UnderestimatedResolve : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Underestimated Resolve");
        Tooltip.SetDefault("Tome\n+20 HP, +5% ranged damage\n+4 defense");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.rare = ItemRarityID.LightPurple;
        Item.width = dims.Width;
        Item.value = 20000;
        Item.height = dims.Height;
        Item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().tome = true;
    }

    public override void UpdateAccessory(Player player, bool hideVisual)
    {
        player.statLifeMax2 += 20;
        player.GetDamage(DamageClass.Ranged) += 0.05f;
        player.statDefense += 4;
    }

    public override void AddRecipes()
    {
        CreateRecipe(1).AddIngredient(ModContent.ItemType<Sandstone>(), 10).AddIngredient(ModContent.ItemType<ElementDust>(), 4).AddIngredient(ModContent.ItemType<MysticalClaw>(), 6).AddIngredient(ModContent.ItemType<MysticalTomePage>(), 2).AddTile(ModContent.TileType<Tiles.TomeForge>()).Register();
    }
}