using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tools
{
	class BlahsWarhammer : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blah's Warhammer");
			Tooltip.SetDefault("You shouldn't have this");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.UseSound = SoundID.Item1;
			item.damage = 80;
			item.autoReuse = true;
			item.hammer = 250;
			item.useTurn = true;
			item.scale = 1.15f;
			item.rare = ItemRarityID.Red;
			item.width = dims.Width;
			item.useTime = 9;
			item.knockBack = 20f;
			item.melee = true;
			item.tileBoost += 6;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.value = 1016000;
			item.useAnimation = 9;
			item.height = dims.Height;
		}
	}
}
