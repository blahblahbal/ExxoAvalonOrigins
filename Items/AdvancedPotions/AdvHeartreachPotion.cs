using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.AdvancedPotions
{
    class AdvHeartreachPotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Heartreach Elixir");
            Tooltip.SetDefault("Increases pickup range for life hearts");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.GetDims("Items/AdvancedPotions/AdvHeartreachPotion");
            Item.buffType = ModContent.BuffType<Buffs.AdvancedBuffs.AdvHeartreach>();
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
            Item.buffTime = 28800 * 2;
        }
    }
}