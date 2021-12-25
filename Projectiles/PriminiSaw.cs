using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ExxoAvalonOrigins.Projectiles
{
	public class PriminiSaw : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Primini");
		}

		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Projectiles/PriminiSaw");
			projectile.netImportant = true;
			projectile.width = dims.Width * 30 / 18;
			projectile.height = dims.Height * 30 / 18 / Main.projFrames[projectile.type];
			projectile.aiStyle = -1;
			projectile.penetrate = -1;
			projectile.timeLeft *= 5;
			projectile.minion = true;
			projectile.minionSlots = 0.25f;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
			projectile.friendly = true;
			Main.projPet[projectile.type] = true;
		}

		public override void AI()
		{
			if (Main.player[projectile.owner].dead)
			{
				Main.player[projectile.owner].GetModPlayer<ExxoAvalonOriginsModPlayer>().primeMinion = false;
			}
			if (Main.player[projectile.owner].GetModPlayer<ExxoAvalonOriginsModPlayer>().primeMinion)
			{
				projectile.timeLeft = 2;
			}
			if (projectile.type == ModContent.ProjectileType<PriminiSaw>())
			{
				if (projectile.position.Y > Main.player[projectile.owner].Center.Y - Main.rand.Next(60, 80))
				{
					if (projectile.velocity.Y > 0f)
					{
						projectile.velocity.Y = projectile.velocity.Y * 0.96f;
					}
					projectile.velocity.Y = projectile.velocity.Y - 0.3f;
					if (projectile.velocity.Y > 6f)
					{
						projectile.velocity.Y = 6f;
					}
				}
				else if (projectile.position.Y < Main.player[projectile.owner].Center.Y - Main.rand.Next(60, 80))
				{
					if (projectile.velocity.Y < 0f)
					{
						projectile.velocity.Y = projectile.velocity.Y * 0.96f;
					}
					projectile.velocity.Y = projectile.velocity.Y + 0.2f;
					if (projectile.velocity.Y < -6f)
					{
						projectile.velocity.Y = -6f;
					}
				}
				if (projectile.Center.X > Main.player[projectile.owner].Center.X + Main.rand.Next(45, 65))
				{
					if (projectile.velocity.X > 0f)
					{
						projectile.velocity.X = projectile.velocity.X * 0.94f;
					}
					projectile.velocity.X = projectile.velocity.X - 0.3f;
					if (projectile.velocity.X > 9f)
					{
						projectile.velocity.X = 9f;
					}
				}
				if (projectile.Center.X < Main.player[projectile.owner].Center.X + Main.rand.Next(45, 65))
				{
					if (projectile.velocity.X < 0f)
					{
						projectile.velocity.X = projectile.velocity.X * 0.94f;
					}
					projectile.velocity.X = projectile.velocity.X + 0.2f;
					if (projectile.velocity.X < -8f)
					{
						projectile.velocity.X = -8f;
					}
				}
				var num956 = ExxoAvalonOriginsGlobalNPC.FindClosest(projectile.position, 640f);
				if (num956 == -1)
				{
					projectile.rotation = 2.35619449f; // +
					return;
				}
				projectile.rotation = Vector2.Normalize(Main.npc[num956].Center - projectile.Center).ToRotation() + 1.57079637f;
				if (Collision.CanHit(projectile.position, projectile.width, projectile.height, Main.npc[num956].position, Main.npc[num956].width, Main.npc[num956].height))
				{
					if (!Main.npc[num956].active)
					{
						projectile.ai[1] = 0f;
						return;
					}
					projectile.ai[1] += 1f;
					if (projectile.ai[1] >= 50f)
					{
						projectile.velocity = Vector2.Normalize(Main.npc[num956].Center - projectile.Center) * 9f;
						return;
					}
				}
			}
		}
	}
}
