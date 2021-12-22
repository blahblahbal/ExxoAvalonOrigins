using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Potions
{
	class BeeRepellent : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bee Repellent");
			Tooltip.SetDefault("Provides immunity to Hornets");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.buffType = ModContent.BuffType<Buffs.BeeSweet>();
			item.UseSound = SoundID.Item3;
			item.consumable = true;
			item.rare = ItemRarityID.Blue;
			item.width = dims.Width;
			item.useTime = 15;
			item.useStyle = ItemUseStyleID.EatingUsing;
			item.maxStack = 100;
			item.useAnimation = 15;
			item.height = dims.Height;
			item.buffTime = 21600;
		}
	}
}
