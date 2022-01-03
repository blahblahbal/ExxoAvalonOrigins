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
	public class MagicGrenade : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Magic Grenade");
		}

		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Projectiles/MagicGrenade");
			projectile.width = dims.Width * 20 / 20;
			projectile.height = dims.Height / Main.projFrames[projectile.type];
			projectile.aiStyle = -1;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.light = 0.9f;
			projectile.alpha = 0;
			projectile.scale = 1f;
			projectile.timeLeft = 240;
			projectile.magic = true;
			aiType = 30;
			projectile.tileCollide = true;
			projectile.CloneDefaults(30);
		}

	    public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough)
	    {
	     	fallThrough = false;
	    	return true;
	    }

		public override void Kill(int timeLeft)
		{
			Main.PlaySound(SoundID.Item14, projectile.position);
			for (int i = 0; i < 15; i++)
			{
				int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 31, 0f, 0f, 100, default(Color), 2f);
				Dust obj = Main.dust[dustIndex];
				obj.velocity *= 1.4f;
			}
			for (int j = 0; j < 10; j++)
			{
				int dustIndex2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, 0f, 0f, 100, default(Color), 3f);
				Main.dust[dustIndex2].noGravity = true;
				Dust obj2 = Main.dust[dustIndex2];
				obj2.velocity *= 5f;
				dustIndex2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, 0f, 0f, 100, default(Color), 2f);
				Dust obj3 = Main.dust[dustIndex2];
				obj3.velocity *= 3f;
			}
			if (Main.myPlayer != projectile.owner)
			{
				return;
			}
		}
	}
}