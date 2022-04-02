using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor;

[AutoloadEquip(EquipType.Legs)]
class OsmiumTreads : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Osmium Treads");
        Tooltip.SetDefault("12% increased magic damage");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.defense = 8;
        Item.rare = ItemRarityID.Orange;
        Item.width = dims.Width;
        Item.value = Item.sellPrice(0, 1, 20, 0);
        Item.height = dims.Height;
    }
    public override void AddRecipes()
    {
        CreateRecipe(1).AddIngredient(ModContent.ItemType<Placeable.Bar.OsmiumBar>(), 17).AddIngredient(ModContent.ItemType<Material.DesertFeather>(), 5).AddTile(TileID.Anvils).Register();
    }
    public override void UpdateEquip(Player player)
    {
        player.GetDamage(DamageClass.Magic) += 0.12f;
    }
}