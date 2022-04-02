using ExxoAvalonOrigins.Items.Material;
using ExxoAvalonOrigins.Items.Placeable.Bar;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tomes;

class TheThreeScholars : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("The Three Scholars");
        Tooltip.SetDefault("Tome\n+20 defense");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.rare = ItemRarityID.Yellow;
        Item.width = dims.Width;
        Item.value = 150000;
        Item.height = dims.Height;
        Item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().tome = true;
    }

    public override void UpdateAccessory(Player player, bool hideVisual)
    {
        player.statDefense += 20;
    }

    public override void AddRecipes()
    {
        CreateRecipe(1).AddIngredient(ModContent.ItemType<DragonOrb>()).AddIngredient(ModContent.ItemType<UnvolanditeBar>(), 25).AddIngredient(ModContent.ItemType<SoulofBlight>(), 10).AddIngredient(ItemID.IronskinPotion, 10).AddIngredient(ModContent.ItemType<MysticalTomePage>(), 5).AddTile(ModContent.TileType<Tiles.TomeForge>()).Register();
        CreateRecipe(1).AddIngredient(ModContent.ItemType<DragonOrb>()).AddIngredient(ModContent.ItemType<VorazylcumBar>(), 25).AddIngredient(ModContent.ItemType<SoulofBlight>(), 10).AddIngredient(ItemID.IronskinPotion, 10).AddIngredient(ModContent.ItemType<MysticalTomePage>(), 5).AddTile(ModContent.TileType<Tiles.TomeForge>()).Register();
    }
}