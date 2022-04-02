using ExxoAvalonOrigins.Items.Material;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tomes;

class TomeofDistance : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Tome of Distance");
        Tooltip.SetDefault("Tome\n+15% ranged damage, +40 HP, +20 mana\n20% chance to not consume ammo");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.rare = ItemRarityID.LightRed;
        Item.width = dims.Width;
        Item.value = 15000;
        Item.height = dims.Height;
        Item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().tome = true;
    }

    public override void UpdateAccessory(Player player, bool hideVisual)
    {
        player.GetDamage(DamageClass.Ranged) += 0.15f;
        player.statLifeMax2 += 40;
        player.statManaMax2 += 20;
    }

    public override void AddRecipes()
    {
        CreateRecipe(1).AddIngredient(ModContent.ItemType<MistyPeachBlossoms>()).AddIngredient(ModContent.ItemType<TaleoftheRedLotus>()).AddIngredient(ModContent.ItemType<MysticalTomePage>()).AddTile(ModContent.TileType<Tiles.TomeForge>()).Register();
    }
}