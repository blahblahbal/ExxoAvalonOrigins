using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories;

[AutoloadEquip(EquipType.Wings)]
class HolyWings : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Holy Wings");
        Tooltip.SetDefault("Allows flight and slow fall\nOther bonuses apply when in the Hallow");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.rare = ItemRarityID.Yellow;
        Item.width = dims.Width;
        Item.value = 600000;
        Item.accessory = true;
        Item.height = dims.Height;
    }
    public override void AddRecipes()
    {
        CreateRecipe(1).AddIngredient(ItemID.AngelWings).AddIngredient(ItemID.CrystalShard, 100).AddIngredient(ItemID.PixieDust, 75).AddTile(TileID.MythrilAnvil).Register();
    }
    public override void UpdateAccessory(Player player, bool hideVisual)
    {
        player.wingTimeMax = 160;
        if (player.ZoneHallow)
        {
            player.statLifeMax2 += 60;
            player.statDefense += 4;
            player.buffImmune[142] = true;
            player.buffImmune[BuffID.Slow] = true;
            player.buffImmune[BuffID.Silenced] = true;
        }
    }
}