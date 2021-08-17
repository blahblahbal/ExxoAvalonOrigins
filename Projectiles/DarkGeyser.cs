using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles
{
	public class DarkGeyser : ModProjectile
	{
		public override string Texture => "Terraria/Projectile_" + ProjectileID.Flames;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dark Geyser");
		}
		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Projectiles/DarkGeyser");
			projectile.width = dims.Width;
			projectile.height = dims.Height;
			projectile.hostile = true;
			projectile.friendly = false;
			projectile.penetrate = -1;
			projectile.aiStyle = -1;
			projectile.tileCollide = true;
			projectile.ignoreWater = true;
			projectile.timeLeft = 50;
			projectile.alpha = 255;
			projectile.extraUpdates = 2;
			projectile.usesIDStaticNPCImmunity = true;
			projectile.idStaticNPCHitCooldown = 10;
		}
        public override void AI()
        {
			if (projectile.ai[0] > 1f)
			{
				float num418 = 1f;
				if (projectile.ai[0] == 8f)
				{
					num418 = 0.25f;
				}
				else if (projectile.ai[0] == 9f)
				{
					num418 = 0.5f;
				}
				else if (projectile.ai[0] == 10f)
				{
					num418 = 0.75f;
				}
				projectile.ai[0] += 1f;
				int num419 = 6;
				if (num419 == 6 || Main.rand.Next(3) == 0)
				{
					for (int num420 = 0; num420 < 1; num420++)
					{
						var num150 = Dust.NewDust(new Vector2(projectile.position.X + projectile.velocity.X, projectile.position.Y + projectile.velocity.Y), projectile.width, projectile.height, 58, projectile.velocity.X, projectile.velocity.Y, 100, default(Color), 1f);
						Main.dust[num150].noGravity = true;
						var num151 = Dust.NewDust(new Vector2(projectile.position.X + projectile.velocity.X, projectile.position.Y + projectile.velocity.Y), projectile.width, projectile.height, 36, projectile.velocity.X, projectile.velocity.Y, 100, default(Color), 1f);
						Main.dust[num151].noGravity = true;
						var randomDust = 0;
						Dust dust98;
						Dust dust189;

						if (Main.rand.NextBool(2))
							randomDust = num150;
						else
							randomDust = num151;

						if (Main.rand.Next(3) != 0 || (num419 == 75 && Main.rand.Next(3) == 0))
						{
							Main.dust[randomDust].noGravity = true;
							dust98 = Main.dust[randomDust];
							dust189 = dust98;
							dust189.scale *= 3f;
							Main.dust[randomDust].velocity.X *= 2f;
							Main.dust[randomDust].velocity.Y *= 2f;
						}
						dust98 = Main.dust[randomDust];
						dust189 = dust98;
						dust189.scale *= 1.5f;
						Main.dust[randomDust].velocity.X *= 1.2f;
						Main.dust[randomDust].velocity.Y *= 1.2f;
						dust98 = Main.dust[randomDust];
						dust189 = dust98;
						dust189.scale *= num418;
					}
				}
			}
			else
			{
				projectile.ai[0] += 1f;
			}
			projectile.rotation += 0.3f * (float)projectile.direction;
		}
		public override void OnHitPlayer(Player target, int damage, bool crit)
		{
			target.AddBuff(ModContent.BuffType<Buffs.DarkInferno>(), 240, false);
		}
		public override void ModifyDamageHitbox(ref Rectangle hitbox)
		{
			int size = 20;
			hitbox.X -= size;
			hitbox.Y -= size;
			hitbox.Width += size * 2;
			hitbox.Height += size * 2;
		}
    }
}