using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;

namespace ExxoAvalonOrigins.Items
{
	class AccelerationDrill : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Acceleration Drill");
			Tooltip.SetDefault("Press N to change mining modes");
		}

		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/AccelerationDrill");
			item.damage = 25;
			item.noUseGraphic = true;
			item.autoReuse = true;
			item.channel = true;
			item.scale = 1f;
			item.shootSpeed = 32f;
			item.pick = 400;
			item.rare = 10;
			item.noMelee = true;
			item.width = dims.Width;
			item.useTime = 7;
			item.knockBack = 1f;
			item.shoot = ModContent.ProjectileType<Projectiles.AccelerationDrill>();
			item.UseSound = SoundID.Item23;
			item.melee = true;
			item.tileBoost += 6;
			item.useStyle = 5;
			item.value = 1016000;
			item.useAnimation = 9;
			item.height = dims.Height;
		}

		public override bool UseItem(Player player)
		{
			if (player.controlUseItem && player.GetModPlayer<ExxoAvalonOriginsModPlayer>().speed && player.position.X / 16f - (float)Player.tileRangeX - (float)player.inventory[player.selectedItem].tileBoost <= (float)Player.tileTargetX && (player.position.X + (float)player.width) / 16f + (float)Player.tileRangeX + (float)player.inventory[player.selectedItem].tileBoost - 1f >= (float)Player.tileTargetX && player.position.Y / 16f - (float)Player.tileRangeY - (float)player.inventory[player.selectedItem].tileBoost <= (float)Player.tileTargetY && (player.position.Y + (float)player.height) / 16f + (float)Player.tileRangeY + (float)player.inventory[player.selectedItem].tileBoost - 2f >= (float)Player.tileTargetY)
			{
				for (int num360 = Player.tileTargetX - 1; num360 <= Player.tileTargetX + 1; num360++)
				{
					for (int num361 = Player.tileTargetY - 1; num361 <= Player.tileTargetY + 1; num361++)
					{
						if (Main.tile[num360, num361].active() && !Main.tileHammer[(int)Main.tile[num360, num361].type] && !Main.tileAxe[(int)Main.tile[num360, num361].type])
						{
							WorldGen.KillTile(num360, num361, false, false, false);
							if (Main.netMode == 1)
							{
								NetMessage.SendData(17, -1, -1, NetworkText.FromLiteral(""), 0, (float)num360, (float)num361, 0f, 0);
							}
						}
					}
				}
			}

			return true;
		}
	}
}