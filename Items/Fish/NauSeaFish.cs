using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Terraria.ID;

namespace ExxoAvalonOrigins.Items.Fish
{
	class NauSeaFish : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nau-Sea-a Fish");
			Tooltip.SetDefault("'Get it?'");
		}

		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/Fish/NauSeaFish");
			item.maxStack = 999;
			item.width = dims.Width;
			item.height = dims.Height;
			item.rare = ItemRarityID.Blue;
			item.value = 7500;
		}
	}
}