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
	class CursedFlamelash : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cursed Flamelash");
			Tooltip.SetDefault("Summons a controllable ball of cursed fire");
		}

		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/CursedFlamelash");
			item.UseSound = SoundID.Item20;
			item.magic = true;
			item.damage = 40;
			item.channel = true;
			item.shootSpeed = 6f;
			item.mana = 17;
			item.rare = 5;
			item.noMelee = true;
			item.width = dims.Width;
			item.useTime = 23;
			item.knockBack = 4f;
			item.shoot = ModContent.ProjectileType<Projectiles.CursedFlamelash>();
			item.useStyle = 1;
			item.value = 250000;
			item.useAnimation = 23;
			item.height = dims.Height;
		}
	}
}