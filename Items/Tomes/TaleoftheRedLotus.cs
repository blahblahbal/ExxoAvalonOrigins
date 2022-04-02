using ExxoAvalonOrigins.Items.Material;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tomes;

class TaleoftheRedLotus : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Tale of the Red Lotus");
        Tooltip.SetDefault("Tome\n+5% ranged damage\n+20 HP");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.rare = ItemRarityID.LightRed;
        Item.width = dims.Width;
        Item.value = 5000;
        Item.height = dims.Height;
        Item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().tome = true;
    }

    public override void UpdateAccessory(Player player, bool hideVisual)
    {
        player.GetDamage(DamageClass.Ranged) += 0.05f;
        player.statLifeMax2 += 20;
    }

    public override void AddRecipes()
    {
        CreateRecipe(1).AddIngredient(ModContent.ItemType<DewOrb>(), 6).AddIngredient(ModContent.ItemType<CarbonSteel>(), 5).AddIngredient(ModContent.ItemType<Sandstone>(), 10).AddIngredient(ItemID.FallenStar, 15).AddIngredient(ModContent.ItemType<MysticalTomePage>(), 4).AddTile(ModContent.TileType<Tiles.TomeForge>()).Register();
    }
}