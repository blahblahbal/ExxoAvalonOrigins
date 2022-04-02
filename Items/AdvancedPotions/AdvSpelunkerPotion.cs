using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.AdvancedPotions;

class AdvSpelunkerPotion : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Spelunker Elixir");
        Tooltip.SetDefault("Shows the location of treasure and ore");
    }

    public override void SetDefaults()
    {
        Rectangle dims = ExxoAvalonOrigins.GetDims("Items/AdvancedPotions/AdvSpelunkerPotion");
        Item.buffType = ModContent.BuffType<Buffs.AdvancedBuffs.AdvSpelunker>();
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
        Item.buffTime = 36000;
    }
}