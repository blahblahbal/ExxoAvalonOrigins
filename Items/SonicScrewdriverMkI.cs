using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ExxoAvalonOrigins.Items
{
	class SonicScrewdriverMkI : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sonic Screwdriver Mk I");
			Tooltip.SetDefault("Reveals treasures, ores, and mobs");
		}

		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/SonicScrewdriverMkI");
			item.rare = ItemRarityID.Orange;
			item.width = dims.Width;
			item.useTime = 70;
			item.value = Item.sellPrice(0, 1, 0, 0);
			item.useStyle = ItemUseStyleID.Stabbing;
			item.useAnimation = 70;
			item.height = dims.Height;
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/SonicScrewdriver");
        }
	}
}