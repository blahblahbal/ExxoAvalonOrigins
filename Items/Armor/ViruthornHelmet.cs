using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor;

[AutoloadEquip(EquipType.Head)]
class ViruthornHelmet : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Viruthorn Helmet");
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
        CreateRecipe(1).AddIngredient(ModContent.ItemType<Placeable.Bar.BacciliteBar>(), 15).AddIngredient(ModContent.ItemType<Material.Booger>(), 5).AddTile(TileID.Anvils).Register();
    }
    public override bool IsArmorSet(Item head, Item body, Item legs)
    {
        return body.type == ModContent.ItemType<ViruthornScalemail>() && legs.type == ModContent.ItemType<ViruthornGreaves>();
    }

    public override void UpdateArmorSet(Player player)
    {
        player.setBonus = "10% increased critical strike chance";
        player.GetCritChance(DamageClass.Melee) += 10;
        player.GetCritChance(DamageClass.Ranged) += 10;
        player.GetCritChance(DamageClass.Magic) += 10;
    }

    public override void UpdateEquip(Player player)
    {
        player.GetDamage(DamageClass.Magic) += 0.03f;
        player.GetDamage(DamageClass.Melee) += 0.03f;
        player.GetDamage(DamageClass.Summon) += 0.03f;
        player.GetDamage(DamageClass.Ranged) += 0.03f;
    }
}