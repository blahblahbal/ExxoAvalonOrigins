using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories;

[AutoloadEquip(EquipType.Wings)]
class CrimsonWings : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Crimson Flaps");
        Tooltip.SetDefault("Allows flight and slow fall\nOther bonuses apply when in the Crimson");
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
        if (player.ZoneCrimson)
        {
            player.statDefense += 5;
            player.statLifeMax2 += 40;
        }
        player.wingTimeMax = 140;
    }
    public override void AddRecipes()
    {
        CreateRecipe(1).AddIngredient(ItemID.DemonWings).AddIngredient(ItemID.Vertebrae, 20).AddIngredient(ItemID.Ichor, 25).AddTile(TileID.MythrilAnvil).Register();
    }
}