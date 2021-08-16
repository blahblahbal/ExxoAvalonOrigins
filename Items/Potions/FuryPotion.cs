using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ExxoAvalonOrigins.Items.Potions
{
    class FuryPotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fury Potion");
            Tooltip.SetDefault("Increases critical strike damage by 30%");
        }

        public override void SetDefaults()
        {
            Rectangle dims = item.modItem.GetDims();
            item.buffType = ModContent.BuffType<Buffs.Fury>();
            item.UseSound = SoundID.Item3;
            item.consumable = true;
            item.rare = ItemRarityID.Blue;
            item.width = dims.Width;
            item.useTime = 15;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.maxStack = 100;
            item.value = Item.sellPrice(0, 0, 2, 0);
            item.useAnimation = 15;
            item.height = dims.Height;
            item.buffTime = 14400;
        }
    }
}