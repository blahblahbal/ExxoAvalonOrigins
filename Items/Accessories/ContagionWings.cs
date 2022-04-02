using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories;

[AutoloadEquip(EquipType.Wings)]
class ContagionWings : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Contagion Wings");
        Tooltip.SetDefault("Allows flight and slow fall\nOther bonuses apply when in the Contagion");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.rare = ItemRarityID.Yellow;
        Item.width = dims.Width;
        Item.value = 400000;
        Item.accessory = true;
        Item.height = dims.Height;
    }

    public override void UpdateAccessory(Player player, bool hideVisual)
    {
        if (player.Avalon().ZoneContagion)
        {
            player.statDefense += 5;
            player.statLifeMax2 += 40;
        }
        player.wingTimeMax = 140;
    }
    public override void AddRecipes()
    {
        CreateRecipe(1).AddIngredient(ItemID.DemonWings).AddIngredient(ModContent.ItemType<Material.YuckyBit>(), 20).AddIngredient(ModContent.ItemType<Material.Pathogen>(), 25).AddTile(TileID.MythrilAnvil).Register();
    }
}