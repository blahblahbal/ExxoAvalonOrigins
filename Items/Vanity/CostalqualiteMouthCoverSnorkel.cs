using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Vanity
{
	[AutoloadEquip(EquipType.Head)]
	class CostalqualiteMouthCoverSnorkel: ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Costalqualite Mouth Cover Snorkel");
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
