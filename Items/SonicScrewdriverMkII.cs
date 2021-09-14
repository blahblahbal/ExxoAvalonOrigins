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
	class SonicScrewdriverMkII : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sonic Screwdriver Mk II");
			Tooltip.SetDefault("Reveals treasures, ores, and mobs\nTells time and shows position");
		}

		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/SonicScrewdriverMkII");
			item.rare = ItemRarityID.LightPurple;
			item.width = dims.Width;
			item.useTime = 70;
			item.value = Item.sellPrice(0, 4, 0, 0);
			item.useStyle = ItemUseStyleID.Stabbing;
			item.useAnimation = 70;
			item.height = dims.Height;
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/SonicScrewdriver");
        }
	}
}