using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories
{
	class CrystalEdge : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crystal Edge");
			Tooltip.SetDefault("Increases damage by 15");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.rare = ItemRarityID.LightRed;
			item.width = dims.Width;
			item.accessory = true;
			item.value = Item.sellPrice(0, 4, 0, 0);
			item.height = dims.Height;
		}

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<ExxoAvalonOriginsModPlayer>().crystalEdge = true;
        }
    }
}
