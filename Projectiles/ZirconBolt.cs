using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;namespace ExxoAvalonOrigins.Projectiles{	public class ZirconBolt : ModProjectile	{		public override void SetStaticDefaults()		{			DisplayName.SetDefault("Zircon Bolt");		}		public override void SetDefaults()		{			Rectangle dims = ExxoAvalonOrigins.getDims("Projectiles/ZirconBolt");			projectile.width = dims.Width * 10 / 16;			projectile.height = dims.Height * 10 / 16 / Main.projFrames[projectile.type];			projectile.aiStyle = -1;			projectile.alpha = 255;			projectile.magic = true;			projectile.light = 0.9f;			projectile.penetrate = 3;			projectile.friendly = true;		}		public override void AI()		{			var num497 = projectile.type - 121 + 86;			if (projectile.type == ModContent.ProjectileType<OpalBolt>())			{				num497 = 227;			}			if (projectile.type == ModContent.ProjectileType<OnyxBolt>())			{				num497 = 36;			}			if (projectile.type == ModContent.ProjectileType<SolarBolt>())			{				num497 = 152;			}			if (projectile.type == ModContent.ProjectileType<KunziteBolt>())			{				num497 = 141;			}			if (projectile.type == ModContent.ProjectileType<TourmalineBolt>())			{				num497 = 111;			}			if (projectile.type == ModContent.ProjectileType<PeridotBolt>())			{				num497 = 110;			}			if (projectile.type == ModContent.ProjectileType<ZirconBolt>())			{				num497 = 216;			}			for (var num498 = 0; num498 < 2; num498++)			{				var num499 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, num497, projectile.velocity.X, projectile.velocity.Y, 50, default(Color), 1.2f);				Main.dust[num499].noGravity = true;				Main.dust[num499].velocity *= 0.3f;			}			if (projectile.ai[1] == 0f)			{				projectile.ai[1] = 1f;				Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 8);			}		}	}}