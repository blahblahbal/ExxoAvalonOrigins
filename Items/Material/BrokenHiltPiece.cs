using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Material
{
	class BrokenHiltPiece : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Broken Hilt Piece");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.rare = ItemRarityID.Blue;
			item.width = dims.Width;
			item.value = 50;
			item.maxStack = 999;
			item.height = dims.Height;
		}
	}
}
