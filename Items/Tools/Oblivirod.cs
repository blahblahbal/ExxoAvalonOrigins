using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tools
{
	class Oblivirod : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Oblivirod");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.shootSpeed = 15.5f;
			item.rare = 12;
			item.width = dims.Width;
			item.useTime = 8;
			item.fishingPole = 110;
			item.shoot = ProjectileID.BobberHotline;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.value = Item.sellPrice(0, 40, 0, 0);
			item.useAnimation = 8;
			item.height = dims.Height;
		}
	}
}
