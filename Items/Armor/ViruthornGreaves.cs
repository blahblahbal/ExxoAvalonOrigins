using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor;

[AutoloadEquip(EquipType.Legs)]
class ViruthornGreaves : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Viruthorn Greaves");
        Tooltip.SetDefault("3% increased damage");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.defense = 6;
        Item.rare = ItemRarityID.Blue;
        Item.width = dims.Width;
        Item.value = Item.sellPrice(0, 0, 54, 0);
        Item.height = dims.Height;
    }
    public override void AddRecipes()
    {
        CreateRecipe(1).AddIngredient(ModContent.ItemType<Placeable.Bar.BacciliteBar>(), 10).AddIngredient(ModContent.ItemType<Material.Booger>(), 5).AddTile(TileID.Anvils).Register();
    }
    public override void UpdateEquip(Player player)
    {
        player.GetDamage(DamageClass.Magic) += 0.03f;
        player.GetDamage(DamageClass.Melee) += 0.03f;
        player.GetDamage(DamageClass.Summon) += 0.03f;
        player.GetDamage(DamageClass.Ranged) += 0.03f;
    }
}