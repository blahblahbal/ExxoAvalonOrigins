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
	class Snotsabre : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Snotsabre");
		}
		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/Snotsabre");
			item.UseSound = SoundID.Item1;
			item.damage = 17;
			item.autoReuse = true;
			item.useTurn = true;
			item.scale = 1.1f;
			item.rare = ItemRarityID.Blue;
			item.width = dims.Width;
			item.useTime = 20;
			item.knockBack = 3f;
			item.melee = true;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.value = Item.sellPrice(0, 0, 36, 0);
			item.useAnimation = 20;
			item.height = dims.Height;
		}
	}
}