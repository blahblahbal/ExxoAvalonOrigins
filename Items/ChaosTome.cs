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
	class ChaosTome : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Chaos Tome");
			Tooltip.SetDefault("Casts a chaos bolt");
		}

		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/ChaosTome");
			item.UseSound = SoundID.Item20;
			item.magic = true;
			item.damage = 24;
			item.autoReuse = true;
			item.useTurn = true;
			item.shootSpeed = 8f;
			item.mana = 8;
			item.noMelee = true;
			item.rare = 2;
			item.width = dims.Width;
			item.useTime = 25;
			item.knockBack = 4f;
			item.shoot = ModContent.ProjectileType<Projectiles.ChaosBolt>();
			item.useStyle = 5;
			item.value = 18400;
			item.useAnimation = 25;
			item.height = dims.Height;
        }
	}
}