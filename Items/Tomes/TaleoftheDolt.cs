using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tomes;

class TaleoftheDolt : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Tale of the Dolt");
        Tooltip.SetDefault("Tome\n+15% melee damage\n+20 HP, +20 mana");
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
        player.GetDamage(DamageClass.Melee) += 0.15f;
        player.statLifeMax2 += 20;
        player.statManaMax2 += 20;
    }

    public override void AddRecipes()
    {
        CreateRecipe(1).AddIngredient(ModContent.ItemType<FlankersTome>()).AddIngredient(ModContent.ItemType<MistyPeachBlossoms>()).AddTile(ModContent.TileType<Tiles.TomeForge>()).Register();
    }
}