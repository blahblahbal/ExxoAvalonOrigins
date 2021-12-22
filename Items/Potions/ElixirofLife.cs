using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Potions
{
	class ElixirofLife : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Elixir of Life");
			Tooltip.SetDefault("'It refreshes you'");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.potion = true;
			item.useTurn = true;
			item.maxStack = 60;
			item.healLife = 350;
			item.consumable = true;
			item.rare = ItemRarityID.Lime;
			item.width = dims.Width;
			item.useTime = 17;
			item.useStyle = ItemUseStyleID.EatingUsing;
			item.value = 10000;
			item.useAnimation = 17;
			item.height = dims.Height;
            item.UseSound = SoundID.Item3;
        }
	}
}
