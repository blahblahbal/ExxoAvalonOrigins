using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.AdvancedPotions;

class AdvBuilderPotion : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Builder Elixir");
        Tooltip.SetDefault("Increased placement speed and range");
    }

    public override void SetDefaults()
    {
        Rectangle dims = Item.modItem.GetDims();
        Item.buffType = ModContent.BuffType<Buffs.AdvancedBuffs.AdvBuilder>();
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
        Item.buffTime = 108000;
    }
}