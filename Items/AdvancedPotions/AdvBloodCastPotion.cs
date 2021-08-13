using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ExxoAvalonOrigins.Items.AdvancedPotions
{
    class AdvBloodCastPotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Advanced Blood Cast Potion");
            Tooltip.SetDefault("Adds your max life to your max mana");
        }

        public override void SetDefaults()
        {
            Rectangle dims = item.modItem.GetDims();
            item.buffType = ModContent.BuffType<Buffs.AdvancedBuffs.AdvBloodCast>();
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
            item.buffTime = 36000;
        }
    }
}