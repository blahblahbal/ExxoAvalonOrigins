using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor;

[AutoloadEquip(EquipType.Head)]
class FleshCap : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Flesh Cap");
        Tooltip.SetDefault("10% increased minion damage");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.defense = 7;
        Item.rare = ItemRarityID.LightRed;
        Item.width = dims.Width;
        Item.value = Item.sellPrice(0, 1, 0, 0);
        Item.height = dims.Height;
    }
    public override void AddRecipes()
    {
        CreateRecipe(1).AddIngredient(ModContent.ItemType<Material.FleshyTendril>(), 12).AddTile(TileID.Anvils).Register();
    }
    public override bool IsArmorSet(Item head, Item body, Item legs)
    {
        return body.type == ModContent.ItemType<FleshWrappings>() && legs.type == ModContent.ItemType<FleshPants>();
    }

    public override void UpdateArmorSet(Player player)
    {
        player.setBonus = "Hungry minions can be summoned up to 10";
        player.Avalon().fleshLaser = true;
    }

    public override void UpdateEquip(Player player)
    {
        player.GetDamage(DamageClass.Summon) += 0.1f;
    }
}