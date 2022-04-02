using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor;

[AutoloadEquip(EquipType.Body)]
class RhodiumPlateMail : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Rhodium Plate Mail");
        Tooltip.SetDefault("14% increased melee damage and speed");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.defense = 7;
        Item.rare = ItemRarityID.Orange;
        Item.width = dims.Width;
        Item.value = Item.sellPrice(0, 1, 0, 0);
        Item.height = dims.Height;
    }
    public override void AddRecipes()
    {
        CreateRecipe(1).AddIngredient(ModContent.ItemType<Placeable.Bar.RhodiumBar>(), 20).AddIngredient(ModContent.ItemType<Material.DesertFeather>(), 6).AddTile(TileID.Anvils).Register();
    }
    public override void UpdateEquip(Player player)
    {
        player.GetDamage(DamageClass.Melee) += 0.14f;
        player.meleeSpeed += 0.14f;
    }
}