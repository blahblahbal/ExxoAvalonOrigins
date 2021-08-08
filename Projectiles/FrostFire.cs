using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles
{
	public class FrostFire : ModProjectile
	{
		public override string Texture => "Terraria/Projectile_" + ProjectileID.Flames;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Frost Fire");
		}
		public override void SetDefaults()
		{
			projectile.width = 6;
			projectile.height = 6;
			projectile.alpha = 255;
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.penetrate = 5;
			projectile.timeLeft = 60;
			projectile.ignoreWater = false;
			projectile.tileCollide = true;
			projectile.ranged = true;
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
				int num419 = 135;
				if (num419 == 135 || Main.rand.Next(3) == 0)
				{
					for (int num420 = 0; num420 < 1; num420++)
					{
						int num421 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, num419, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 100, default, 1f);
						Dust dust98;
						Dust dust189;
						if (Main.rand.Next(3) != 0 || (num419 == 75 && Main.rand.Next(3) == 0))
						{
							Main.dust[num421].noGravity = true;
							dust98 = Main.dust[num421];
							dust189 = dust98;
							dust189.scale *= 3f;
							Main.dust[num421].velocity.X *= 2f;
							Main.dust[num421].velocity.Y *= 2f;
						}
						if (projectile.type == 188)
						{
							dust98 = Main.dust[num421];
							dust189 = dust98;
							dust189.scale *= 1.25f;
						}
						else
						{
							dust98 = Main.dust[num421];
							dust189 = dust98;
							dust189.scale *= 1.5f;
						}
						Main.dust[num421].velocity.X *= 1.2f;
						Main.dust[num421].velocity.Y *= 1.2f;
						dust98 = Main.dust[num421];
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
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			Projectile.NewProjectile(new Vector2(projectile.Center.X, projectile.Center.Y), new Vector2(0f, 0f), ModContent.ProjectileType<Projectiles.FrostFireLinger>(), projectile.damage, projectile.knockBack, projectile.owner);
			return true;
		}
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.Frostburn, 240);
		}
		public override void OnHitPlayer(Player target, int damage, bool crit)
		{
			target.AddBuff(BuffID.Frostburn, 240, false);
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
	public class FrostFireLinger : ModProjectile
	{
		public override string Texture => "Terraria/Projectile_" + ProjectileID.Flames;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Frost Fire Linger");
		}
		public override void SetDefaults()
		{
			projectile.width = 20;
			projectile.height = 20;
			projectile.alpha = 255;
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.penetrate = -1;
			projectile.timeLeft = 200 + Main.rand.Next(50, 100);
			projectile.ignoreWater = false;
			projectile.tileCollide = false;
			projectile.ranged = true;
			projectile.usesIDStaticNPCImmunity = true;
			projectile.idStaticNPCHitCooldown = 10;
		}
        public override void AI()
        {
			for (int i = 0; i < 1; i++)
			{
				int num421 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 135, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 100, default, 3f);
				Main.dust[num421].velocity.X *= 3f;
				Main.dust[num421].velocity.Y *= 3.5f;
				Main.dust[num421].noGravity = true;
			}
		}
		public override void ModifyDamageHitbox(ref Rectangle hitbox)
		{
			int size = 15;
			hitbox.X -= size;
			hitbox.Y -= size;
			hitbox.Width += size * 2;
			hitbox.Height += size * 2;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.Frostburn, 240);
		}
		public override void OnHitPlayer(Player target, int damage, bool crit)
		{
			target.AddBuff(BuffID.Frostburn, 240, false);
		}
	}
}
