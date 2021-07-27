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
	class CrystalFruit : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crystal Fruit");
			Tooltip.SetDefault("Permanently increases maximum life by 25\nCan only be used when you have 500 or more life");
		}

		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/CrystalFruit");
			item.UseSound = SoundID.Item4;
			item.consumable = true;
			item.rare = 9;
			item.width = dims.Width;
			item.useTime = 30;
			item.maxStack = 999;
			item.useStyle = 4;
			item.value = Item.sellPrice(0, 3, 0, 0);
			item.useAnimation = 30;
			item.height = dims.Height;
		}

        public override bool CanUseItem(Player player)
        {
            return player.statLifeMax >= 500 && player.GetModPlayer<ExxoAvalonOriginsModPlayer>().crystalHealth < 4;
        }

        public override bool UseItem(Player player)
        {
            player.GetModPlayer<ExxoAvalonOriginsModPlayer>().crystalHealth += 1;
            player.statLifeMax += 25;
            player.statLife += 25;
            player.statLifeMax2 += 25;
            return true;
        }
    }
}