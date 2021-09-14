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
	class FocusBeam : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Focus Beam");
			Tooltip.SetDefault("Fires a wide-beam laser");
		}

		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/FocusBeam");
			item.magic = true;
			item.damage = 47;
			item.autoReuse = true;
			item.useTurn = true;
			item.scale = 1f;
			item.shootSpeed = 15f;
			item.crit += 1;
			item.mana = 18;
			item.rare = ItemRarityID.Orange;
			item.noMelee = true;
			item.width = dims.Width;
			item.useTime = 27;
			item.knockBack = 5f;
			item.shoot = ModContent.ProjectileType<Projectiles.FocusBeam>();
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.value = 388500;
			item.useAnimation = 27;
			item.height = dims.Height;
		}
	}
}