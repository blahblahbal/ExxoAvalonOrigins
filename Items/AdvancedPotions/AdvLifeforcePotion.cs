using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.AdvancedPotions;

class AdvLifeforcePotion : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Lifeforce Elixir");
        Tooltip.SetDefault("Increases max life by 40%");
    }

    public override void SetDefaults()
    {
        Rectangle dims = ExxoAvalonOrigins.GetDims("Items/AdvancedPotions/AdvLifeforcePotion");
        Item.buffType = ModContent.BuffType<Buffs.AdvancedBuffs.AdvLifeforce>();
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