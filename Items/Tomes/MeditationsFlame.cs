using ExxoAvalonOrigins.Items.Material;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tomes;

class MeditationsFlame : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Meditation's Flame");
        Tooltip.SetDefault("Tome\n+5% magic damage, -10% mana cost\n+60 mana");
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
        player.GetDamage(DamageClass.Magic) += 0.05f;
        player.manaCost -= 0.1f;
        player.statManaMax2 += 60;
    }

    public override void AddRecipes()
    {
        CreateRecipe(1).AddIngredient(ModContent.ItemType<RubybeadHerb>(), 5).AddIngredient(ModContent.ItemType<FineLumber>(), 20).AddIngredient(ItemID.FallenStar, 60).AddIngredient(ItemID.MeteoriteBar, 10).AddIngredient(ModContent.ItemType<MysticalTomePage>(), 2).AddTile(ModContent.TileType<Tiles.TomeForge>()).Register();
    }
}