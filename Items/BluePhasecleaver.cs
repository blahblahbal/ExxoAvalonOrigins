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
	class BluePhasecleaver : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blue Phasecleaver");
		}

		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/BluePhasecleaver");
			item.damage = 80;
			item.UseSound = SoundID.Item15;
			item.autoReuse = true;
			item.scale = 1.2f;
			item.useTurn = true;
			item.rare = 7;
			item.width = dims.Width;
			item.useTime = 20;
			item.knockBack = 5.25f;
			item.melee = true;
			item.value = 70000;
			item.useStyle = 1;
			item.useAnimation = 20;
			item.height = dims.Height;
		}
	}
}