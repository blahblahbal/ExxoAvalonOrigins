using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Material
{
	class IceGel : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ice Gel");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.rare = ItemRarityID.White;
			item.width = dims.Width;
			item.value = 700;
			item.maxStack = 999;
			item.height = dims.Height;
		}
	}
}
