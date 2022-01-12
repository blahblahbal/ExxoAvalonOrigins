using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	class CostalliteTreddings : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Costallite Treddings");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.rare = ItemRarityID.Green;
			item.width = dims.Width;
			item.defense = 8;
			item.value = Item.sellPrice(0, 1, 50, 0);
			item.height = dims.Height;
		}
	}
}
