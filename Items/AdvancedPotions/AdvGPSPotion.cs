using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.AdvancedPotions
{
    class AdvGPSPotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("GPS Elixir");
            Tooltip.SetDefault("GPS Effect");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.GetDims("Items/AdvancedPotions/AdvGPSPotion");
            Item.buffType = ModContent.BuffType<Buffs.AdvancedBuffs.AdvGPS>();
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