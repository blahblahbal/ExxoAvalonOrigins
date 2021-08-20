using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;namespace ExxoAvalonOrigins.Projectiles{	public class LightningTrail : ModProjectile	{		public override void SetStaticDefaults()		{			DisplayName.SetDefault("Lightning");		}		public override void SetDefaults()		{			projectile.width = 8;			projectile.height = 8;			projectile.scale = 1f;			projectile.alpha = 100;			projectile.aiStyle = -1;			projectile.timeLeft = 100;			projectile.friendly = true;			projectile.penetrate = 100;			projectile.ignoreWater = true;			projectile.tileCollide = false;		}
		public override void AI()
		{
			projectile.alpha = 255 - (projectile.timeLeft * 2) - (int)(25 * projectile.scale);
			if (projectile.alpha < 100) projectile.alpha = 0;
		}
	}}