using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;using Terraria.Localization;namespace ExxoAvalonOrigins.Projectiles{	public class PeridotHook : ModProjectile	{		public override void SetStaticDefaults()		{			DisplayName.SetDefault("Peridot Hook");		}		public override void SetDefaults()		{			projectile.CloneDefaults(ProjectileID.GemHookEmerald);			//Rectangle dims = ExxoAvalonOrigins.getDims("Projectiles/PeridotHook");			//projectile.netImportant = true;			//projectile.width = dims.Width * 18 / 18;			//projectile.height = dims.Height / Main.projFrames[projectile.type];			//projectile.aiStyle = -1;			//projectile.friendly = true;			//projectile.penetrate = 1;			//projectile.tileCollide = false;			//projectile.timeLeft *= 10;		}

		//public override void AI()
		//{
		//	if (Main.player[projectile.owner].dead)
		//	{
		//		projectile.Kill();
		//		return;
		//	}
		//	var vector9 = new Vector2(projectile.position.X + projectile.width * 0.5f, projectile.position.Y + projectile.height * 0.5f);
		//	var num119 = Main.player[projectile.owner].position.X + Main.player[projectile.owner].width / 2 - vector9.X;
		//	var num120 = Main.player[projectile.owner].position.Y + Main.player[projectile.owner].height / 2 - vector9.Y;
		//	var num121 = (float)Math.Sqrt(num119 * num119 + num120 * num120);
		//	projectile.rotation = (float)Math.Atan2(num120, num119) - 1.57f;
		//	if (projectile.ai[0] == 0f)
		//	{
		//		if ((num121 > 450f && projectile.type == ModContent.ProjectileType<OnyxHook>()) || (num121 > 510f && projectile.type == ModContent.ProjectileType<TourmalineHook>()) || (num121 > 540f && projectile.type == ModContent.ProjectileType<PeridotHook>()) || (num121 > 600f && projectile.type == ModContent.ProjectileType<ZirconHook>()))
		//		{
		//			projectile.ai[0] = 1f;
		//		}
		//		else if (projectile.type == ModContent.ProjectileType<OnyxHook>())
		//		{
		//			var num122 = 300 + (projectile.type - 230) * 30;
		//			if (num121 > num122)
		//			{
		//				projectile.ai[0] = 1f;
		//			}
		//		}
		//		var num123 = (int)(projectile.position.X / 16f) - 1;
		//		var num124 = (int)((projectile.position.X + projectile.width) / 16f) + 2;
		//		var num125 = (int)(projectile.position.Y / 16f) - 1;
		//		var num126 = (int)((projectile.position.Y + projectile.height) / 16f) + 2;
		//		if (num123 < 0)
		//		{
		//			num123 = 0;
		//		}
		//		if (num124 > Main.maxTilesX)
		//		{
		//			num124 = Main.maxTilesX;
		//		}
		//		if (num125 < 0)
		//		{
		//			num125 = 0;
		//		}
		//		if (num126 > Main.maxTilesY)
		//		{
		//			num126 = Main.maxTilesY;
		//		}
		//		for (var num127 = num123; num127 < num124; num127++)
		//		{
		//			var num128 = num125;
		//			while (num128 < num126)
		//			{
		//				if (Main.tile[num127, num128] == null)
		//				{
		//					Main.tile[num127, num128] = new Tile();
		//				}
		//				Vector2 vector10;
		//				vector10.X = num127 * 16;
		//				vector10.Y = num128 * 16;
		//				if (projectile.position.X + projectile.width > vector10.X && projectile.position.X < vector10.X + 16f && projectile.position.Y + projectile.height > vector10.Y && projectile.position.Y < vector10.Y + 16f && Main.tile[num127, num128].nactive() && (Main.tileSolid[Main.tile[num127, num128].type] || Main.tile[num127, num128].type == 314) && (projectile.type != ProjectileID.TrackHook || Main.tile[num127, num128].type == 314))
		//				{
		//					if (Main.player[projectile.owner].grapCount < 10)
		//					{
		//						Main.player[projectile.owner].grappling[Main.player[projectile.owner].grapCount] = projectile.whoAmI;
		//						Main.player[projectile.owner].grapCount++;
		//					}
		//					if (Main.myPlayer == projectile.owner)
		//					{
		//						var num129 = 0;
		//						var num130 = -1;
		//						var num131 = 100000;
		//							var num133 = 3;
		//						if (projectile.type == ModContent.ProjectileType<OnyxHook>() || projectile.type == ModContent.ProjectileType<TourmalineHook>() || projectile.type == ModContent.ProjectileType<PeridotHook>() || projectile.type == ModContent.ProjectileType<ZirconHook>())
		//						{
		//							num133 = 1;
		//						}
		//						for (var num134 = 0; num134 < 1000; num134++)
		//						{
		//							if (Main.projectile[num134].active && Main.projectile[num134].owner == projectile.owner && Main.projectile[num134].aiStyle == 7)
		//							{
		//								if (Main.projectile[num134].timeLeft < num131)
		//								{
		//									num130 = num134;
		//									num131 = Main.projectile[num134].timeLeft;
		//								}
		//								num129++;
		//							}
		//						}
		//						if (num129 > num133)
		//						{
		//							Main.projectile[num130].Kill();
		//						}
		//					}
		//					WorldGen.KillTile(num127, num128, true, true, false);
		//					Main.PlaySound(0, num127 * 16, num128 * 16, 1);
		//					projectile.velocity.X = 0f;
		//					projectile.velocity.Y = 0f;
		//					projectile.ai[0] = 2f;
		//					projectile.position.X = num127 * 16 + 8 - projectile.width / 2;
		//					projectile.position.Y = num128 * 16 + 8 - projectile.height / 2;
		//					if (projectile.type != ModContent.ProjectileType<OnyxHook>())
		//					{
		//						projectile.damage = 0;
		//					}
		//					projectile.netUpdate = true;
		//					if (Main.myPlayer == projectile.owner)
		//					{
		//						NetMessage.SendData(13, -1, -1, NetworkText.FromLiteral(""), projectile.owner, 0f, 0f, 0f, 0);
		//						break;
		//					}
		//					break;
		//				}
		//				else
		//				{
		//					num128++;
		//				}
		//			}
		//			if (projectile.ai[0] == 2f)
		//			{
		//				break;
		//			}
		//		}
		//	}
		//	else if (projectile.ai[0] == 1f)
		//	{
		//		var num135 = 11f;
		//		if (projectile.type == ModContent.ProjectileType<TourmalineHook>())
		//		{
		//			num135 = 20f;
		//		}
		//		if (projectile.type == ModContent.ProjectileType<PeridotHook>() || projectile.type == ModContent.ProjectileType<ZirconHook>())
		//		{
		//			num135 = 20f;
		//		}
		//		if (projectile.type == ModContent.ProjectileType<OnyxHook>())
		//		{
		//			num135 = 25f;
		//		}
		//		if (num121 < 24f)
		//		{
		//			projectile.Kill();
		//		}
		//		num121 = num135 / num121;
		//		num119 *= num121;
		//		num120 *= num121;
		//		projectile.velocity.X = num119;
		//		projectile.velocity.Y = num120;
		//	}
		//	else if (projectile.ai[0] == 2f)
		//	{
		//		var num136 = (int)(projectile.position.X / 16f) - 1;
		//		var num137 = (int)((projectile.position.X + projectile.width) / 16f) + 2;
		//		var num138 = (int)(projectile.position.Y / 16f) - 1;
		//		var num139 = (int)((projectile.position.Y + projectile.height) / 16f) + 2;
		//		if (num136 < 0)
		//		{
		//			num136 = 0;
		//		}
		//		if (num137 > Main.maxTilesX)
		//		{
		//			num137 = Main.maxTilesX;
		//		}
		//		if (num138 < 0)
		//		{
		//			num138 = 0;
		//		}
		//		if (num139 > Main.maxTilesY)
		//		{
		//			num139 = Main.maxTilesY;
		//		}
		//		var flag3 = true;
		//		for (var num140 = num136; num140 < num137; num140++)
		//		{
		//			for (var num141 = num138; num141 < num139; num141++)
		//			{
		//				if (Main.tile[num140, num141] == null)
		//				{
		//					Main.tile[num140, num141] = new Tile();
		//				}
		//				Vector2 vector11;
		//				vector11.X = num140 * 16;
		//				vector11.Y = num141 * 16;
		//				if (projectile.position.X + projectile.width / 2 > vector11.X && projectile.position.X + projectile.width / 2 < vector11.X + 16f && projectile.position.Y + projectile.height / 2 > vector11.Y && projectile.position.Y + projectile.height / 2 < vector11.Y + 16f && Main.tile[num140, num141].nactive() && (Main.tileSolid[Main.tile[num140, num141].type] || Main.tile[num140, num141].type == 314))
		//				{
		//					flag3 = false;
		//				}
		//			}
		//		}
		//		if (flag3)
		//		{
		//			projectile.ai[0] = 1f;
		//		}
		//		else if (Main.player[projectile.owner].grapCount < 10)
		//		{
		//			Main.player[projectile.owner].grappling[Main.player[projectile.owner].grapCount] = projectile.whoAmI;
		//			Main.player[projectile.owner].grapCount++;
		//		}
		//	}
		//}
		public override float GrappleRange()		{			return 540f;		}		public override void NumGrappleHooks(Player player, ref int numHooks)
		{
			numHooks = 1;
		}
	}}