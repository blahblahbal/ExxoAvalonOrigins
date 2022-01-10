using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Vanity
{
	[AutoloadEquip(EquipType.Body)]
	class CostalqualiteVestplate : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Costalqualite Vestplate");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.rare = ItemRarityID.Cyan;
			item.width = dims.Width;
			item.vanity = true;
			item.value = Item.sellPrice(0, 20, 0, 0);
			item.height = dims.Height;
		}
	}
}
