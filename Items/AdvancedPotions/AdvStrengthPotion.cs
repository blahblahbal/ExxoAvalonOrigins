using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.AdvancedPotions
{
    class AdvStrengthPotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Strength Elixir");
            Tooltip.SetDefault("Increases all stats");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.GetDims("Items/AdvancedPotions/AdvStrengthPotion");
            item.buffType = ModContent.BuffType<Buffs.AdvancedBuffs.AdvStrength>();
            item.UseSound = SoundID.Item3;
            item.consumable = true;
            item.rare = ItemRarityID.Lime;
            item.width = dims.Width;
            item.useTime = 15;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.maxStack = 100;
            item.value = Item.sellPrice(0, 0, 4, 0);
            item.useAnimation = 15;
            item.height = dims.Height;
            item.buffTime = 3600 * 18;
        }
    }
}