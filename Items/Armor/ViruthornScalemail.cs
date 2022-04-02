using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor;

[AutoloadEquip(EquipType.Body)]
class ViruthornScalemail : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Viruthorn Scalemail");
        Tooltip.SetDefault("7% increased melee speed");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.defense = 8;
        Item.rare = ItemRarityID.Blue;
        Item.width = dims.Width;
        Item.value = Item.sellPrice(0, 0, 54, 0);
        Item.height = dims.Height;
    }
    public override void AddRecipes()
    {
        CreateRecipe(1).AddIngredient(ModContent.ItemType<Placeable.Bar.BacciliteBar>(), 20).AddIngredient(ModContent.ItemType<Material.Booger>(), 5).AddTile(TileID.Anvils).Register();
    }
    public override void UpdateEquip(Player player)
    {
        player.meleeSpeed += 0.07f;
    }
}