using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;namespace ExxoAvalonOrigins.Projectiles{	public class Lightning : ModProjectile	{		public override void SetStaticDefaults()		{			DisplayName.SetDefault("Lightning");		}		public override void SetDefaults()		{			Rectangle dims = ExxoAvalonOrigins.getDims("Projectiles/Lightning");			projectile.width = dims.Width * 86 / 120;			projectile.height = dims.Height * 86 / 120 / Main.projFrames[projectile.type];			projectile.friendly = true;			projectile.ranged = true;			projectile.tileCollide = false;			projectile.penetrate = -1;			projectile.timeLeft = 3600;			projectile.alpha = 20;			projectile.aiStyle = -1;			projectile.light = 1.5f;		}		public override void AI()		{			if (projectile.type == ModContent.ProjectileType<Lightning>())			{				projectile.alpha += 2;				if (projectile.alpha > 200)				{					projectile.active = false;					return;				}			}			else if (projectile.type == ModContent.ProjectileType<LightningCloud>())			{				projectile.ai[0] += 1f;				var num973 = 0;				if (projectile.ai[0] == 11f)				{					num973 = Projectile.NewProjectile(projectile.position.X + 20f, projectile.position.Y + projectile.width, 0f, 0f, ModContent.ProjectileType<Lightning>(), 40, 4f, projectile.owner, 0f, 0f);					Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 59);					projectile.ai[0] = 12f;				}				if (projectile.ai[0] > 11f)				{					projectile.alpha += 2;					if (projectile.alpha > 200)					{						projectile.active = false;						Main.projectile[num973].active = false;						return;					}				}			}		}	}}