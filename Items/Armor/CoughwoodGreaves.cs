using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	class CoughwoodGreaves : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Coughwood Greaves");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.defense = 2;
			item.width = dims.Width;
			item.value = Item.sellPrice(0, 0, 1, 0);
			item.height = dims.Height;
		}
	}
}
