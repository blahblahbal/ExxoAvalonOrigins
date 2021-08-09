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

namespace ExxoAvalonOrigins.Projectiles
{
	public class Rainbringer : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Rainbringer");
		}

		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Projectiles/Rainbringer");
			projectile.aiStyle = -1;
			projectile.width = dims.Width;
			projectile.height = dims.Height / Main.projFrames[projectile.type];
			projectile.damage = 0;
			projectile.tileCollide = false;
		}

		public override void AI()
		{
			if (projectile.active)
			{
				if (!Main.raining)
				{
					ExxoAvalonOrigins.StartRain();
					if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText("A rain event has started.", 0, 148, 255, false);
					}
					else if (Main.netMode == NetmodeID.Server)
					{
						NetMessage.SendData(25, -1, -1, NetworkText.FromLiteral("A rain event has started."), 255, 0f, 148f, 255f, 0);
					}
				}
				else
				{
					ExxoAvalonOrigins.StopRain();
					if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText("The rain has stopped.", 0, 148, 255, false);
					}
					else if (Main.netMode == NetmodeID.Server)
					{
						NetMessage.SendData(25, -1, -1, NetworkText.FromLiteral("The rain has stopped."), 255, 0f, 148f, 255f, 0);
					}
				}
				projectile.active = false;
				return;
			}
		}
	}
}