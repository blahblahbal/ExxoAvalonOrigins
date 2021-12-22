using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Potions
{
	class WisdomPotion : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Wisdom Potion");
			Tooltip.SetDefault("-8% magic damage, +60 mana");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.buffType = ModContent.BuffType<Buffs.Wisdom>();
			item.consumable = true;
			item.rare = ItemRarityID.Orange;
			item.width = dims.Width;
			item.useTime = 15;
			item.useStyle = ItemUseStyleID.EatingUsing;
			item.maxStack = 100;
			item.useAnimation = 15;
			item.height = dims.Height;
			item.buffTime = 14400;
            item.UseSound = SoundID.Item3;
        }
	}
}
