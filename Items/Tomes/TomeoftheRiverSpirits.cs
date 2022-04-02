using ExxoAvalonOrigins.Items.Material;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tomes;

class TomeoftheRiverSpirits : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Tome of the River Spirits");
        Tooltip.SetDefault("Tome\n+15% magic and minion damage\n-5% mana cost");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.rare = ItemRarityID.Pink;
        Item.width = dims.Width;
        Item.value = 15000;
        Item.height = dims.Height;
        Item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().tome = true;
    }

    public override void UpdateAccessory(Player player, bool hideVisual)
    {
        player.GetDamage(DamageClass.Magic) += 0.15f;
        player.GetDamage(DamageClass.Summon) += 0.15f;
        player.manaCost -= 0.05f;
    }

    public override void AddRecipes()
    {
        CreateRecipe(1).AddIngredient(ModContent.ItemType<MeditationsFlame>()).AddIngredient(ModContent.ItemType<EternitysMoon>()).AddIngredient(ItemID.FallenStar, 20).AddIngredient(ModContent.ItemType<MysticalTomePage>()).AddTile(ModContent.TileType<Tiles.TomeForge>()).Register();
    }
}