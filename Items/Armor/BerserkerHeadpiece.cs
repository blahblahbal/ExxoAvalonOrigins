using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor;

[AutoloadEquip(EquipType.Head)]
class BerserkerHeadpiece : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Berserker Headpiece");
        Tooltip.SetDefault("32% increased melee damage and 20% increased melee speed\n5% decreased melee critical strike chance");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.defense = 36;
        Item.rare = ItemRarityID.Red;
        Item.width = dims.Width;
        Item.value = Item.sellPrice(0, 55, 0, 0);
        Item.height = dims.Height;
    }

    public override bool IsArmorSet(Item head, Item body, Item legs)
    {
        return body.type == ModContent.ItemType<BerserkerBodyarmor>() && legs.type == ModContent.ItemType<BerserkerCuisses>();
    }
    public override void AddRecipes()
    {
        CreateRecipe(1).AddIngredient(ModContent.ItemType<Placeable.Bar.BerserkerBar>(), 20).AddIngredient(ModContent.ItemType<AncientHeadpiece>()).AddIngredient(ModContent.ItemType<Placeable.Tile.Onyx>(), 15).AddTile(ModContent.TileType<Tiles.SolariumAnvil>()).Register();
    }
    public override void UpdateArmorSet(Player player)
    {
        player.setBonus = "Melee weapons have a chance to instantly kill your enemies";
        player.Avalon().oblivionKill = true;
    }

    public override void UpdateEquip(Player player)
    {
        player.GetDamage(DamageClass.Melee) += 0.32f;
        player.meleeSpeed += 0.2f;
        player.GetCritChance(DamageClass.Melee) -= 5;
    }
}