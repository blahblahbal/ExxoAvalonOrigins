using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories
{
	class CloudGloves : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cloud Gloves");
			Tooltip.SetDefault("The wearer can place blocks and walls in midair");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.rare = ItemRarityID.LightRed;
			item.width = dims.Width;
			item.accessory = true;
			item.value = Item.sellPrice(0, 1, 0, 0);
			item.height = dims.Height;
		}
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<ExxoAvalonOriginsModPlayer>().cloudGloves = true;
        }
    }
}
