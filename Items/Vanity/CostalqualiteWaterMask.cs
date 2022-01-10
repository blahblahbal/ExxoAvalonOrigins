using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Vanity
{
	[AutoloadEquip(EquipType.Head)]
	class CostalqualiteWaterMask : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Costalqualite Water Mask");
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
		
		public override void DrawHair(ref bool drawHair, ref bool drawAltHair)
	    {
    		drawHair = (drawAltHair = true);
	    }
	}
}
