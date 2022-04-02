using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.AdvancedPotions;

class AdvArcheryPotion : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Archery Elixir");
        Tooltip.SetDefault("40% increased arrow speed and damage");
    }

    public override void SetDefaults()
    {
        Rectangle dims = Item.modItem.GetDims();
        Item.buffType = ModContent.BuffType<Buffs.AdvancedBuffs.AdvArchery>();
        Item.UseSound = SoundID.Item3;
        Item.consumable = true;
        Item.rare = ItemRarityID.Lime;
        Item.width = dims.Width;
        Item.useTime = 15;
        Item.useStyle = ItemUseStyleID.EatFood;
        Item.maxStack = 100;
        Item.value = Item.sellPrice(0, 0, 4, 0);
        Item.useAnimation = 15;
        Item.height = dims.Height;
        Item.buffTime = 28800;
    }
}