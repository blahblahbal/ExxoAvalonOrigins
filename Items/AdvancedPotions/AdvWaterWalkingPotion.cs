using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.AdvancedPotions
{
    class AdvWaterWalkingPotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Water Walking Elixir");
            Tooltip.SetDefault("Allows the ability to walk on liquids");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.GetDims("Items/AdvancedPotions/AdvWaterWalkingPotion");
            Item.buffType = ModContent.BuffType<Buffs.AdvancedBuffs.AdvWaterWalking>();
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
}