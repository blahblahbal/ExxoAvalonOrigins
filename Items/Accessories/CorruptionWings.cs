using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories;

[AutoloadEquip(EquipType.Wings)]
class CorruptionWings : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Corruption Wings");
        Tooltip.SetDefault("Allows flight and slow fall\nOther bonuses apply when in the Corruption");
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
        if (player.ZoneCorrupt)
        {
            player.statDefense += 5;
            player.statLifeMax2 += 40;
        }
        player.wingTimeMax = 140;
    }
    public override void AddRecipes()
    {
        CreateRecipe(1).AddIngredient(ItemID.DemonWings).AddIngredient(ItemID.RottenChunk, 20).AddIngredient(ItemID.CursedFlame, 25).AddTile(TileID.MythrilAnvil).Register();
    }
}