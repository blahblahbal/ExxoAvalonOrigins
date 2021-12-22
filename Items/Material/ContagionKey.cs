using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Material
{
	class ContagionKey : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Contagion Key");
			Tooltip.SetDefault("Opens a Contagion Chest in the Dungeon");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.rare = ItemRarityID.Yellow;
			item.width = dims.Width;
			item.scale = 1f;
			item.maxStack = 999;
			item.height = dims.Height;
		}
	}
}
