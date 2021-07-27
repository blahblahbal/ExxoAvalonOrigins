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
	class AxeofSickness : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Axe of Sickness");
		}

		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/AxeofSickness");
			item.damage = 15;
			item.autoReuse = true;
			item.useTurn = true;
			item.scale = 1f;
			item.axe = 12;
			item.rare = 1;
			item.width = dims.Width;
			item.useTime = 20;
			item.knockBack = 0.5f;
			item.melee = true;
			item.useStyle = 1;
			item.value = Item.sellPrice(0, 0, 36, 0);
			item.UseSound = SoundID.Item1;
			item.useAnimation = 20;
			item.height = dims.Height;
		}
    }
}