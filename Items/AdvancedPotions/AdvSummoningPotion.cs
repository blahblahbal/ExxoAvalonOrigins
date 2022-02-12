using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.AdvancedPotions
{
    class AdvSummoningPotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Summoning Elixir");
            Tooltip.SetDefault("Increases your max number of minions");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.GetDims("Items/AdvancedPotions/AdvSummoningPotion");
            item.buffType = ModContent.BuffType<Buffs.AdvancedBuffs.AdvSummoning>();
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
            item.buffTime = 43200;
        }
    }
}