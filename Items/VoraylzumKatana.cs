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
	class VoraylzumKatana : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Vorazylcum Katana");
		}

		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/VoraylzumKatana");
			item.damage = 111;
			item.autoReuse = true;
			item.rare = ItemRarityID.Red;
			item.width = dims.Width;
			item.knockBack = 4f;
			item.useTime = 17;
			item.melee = true;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.value = Item.sellPrice(0, 10, 90, 0);
			item.useAnimation = 17;
			item.height = dims.Height;
            item.UseSound = SoundID.Item1;
        }
	}
}