using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles
{
    public class SnotOrb : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Snot Orb");
            Main.projFrames[projectile.type] = 1;
            Main.projPet[projectile.type] = true;
            ProjectileID.Sets.LightPet[projectile.type] = true;
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.GetDims("Projectiles/SnotOrb");
            projectile.netImportant = true;
            projectile.width = 30;
            projectile.height = 30;
            projectile.aiStyle = -1;
            projectile.penetrate = -1;
            projectile.timeLeft *= 5;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
            projectile.friendly = true;
            projectile.light = 0.9f;
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            return false;
        }
        public override void AI()
        {
			projectile.rotation += 0.02f;
            for (int q = 0; q < 4; q++)
            {
                if (Main.rand.Next(30) == 0)
                {
                    int d = Dust.NewDust(projectile.position, 8, 8, DustID.GreenBlood, 0f, 0f, 0, default, 1f);
                    Main.dust[d].noGravity = true;
                    Main.dust[d].velocity *= 3f;
                }
            }
            if (!Main.player[projectile.owner].active)
            {
                projectile.active = false;
                return;
            }
            if (Main.player[projectile.owner].dead)
            {
                Main.player[projectile.owner].Avalon().snotOrb = false;
            }
            if (Main.myPlayer == projectile.owner)
			{
				if (projectile.type == ModContent.ProjectileType<SnotOrb>())
				{
					if (Main.player[projectile.owner].Avalon().snotOrb)
					{
						projectile.timeLeft = 2;
					}
				}
			}
			if (!Main.player[projectile.owner].dead)
			{
				float num179 = 3f;
				Vector2 vector14 = new Vector2(projectile.position.X + projectile.width * 0.5f, projectile.position.Y + projectile.height * 0.5f);
				float num180 = Main.player[projectile.owner].position.X + Main.player[projectile.owner].width / 2 - vector14.X;
				float num181 = Main.player[projectile.owner].position.Y + Main.player[projectile.owner].height / 2 - vector14.Y;
				int num182 = 70;
				if (projectile.type == ModContent.ProjectileType<SnotOrb>())
				{
					if (Main.player[projectile.owner].controlUp)
					{
						num181 = Main.player[projectile.owner].position.Y - 40f - vector14.Y;
						num180 -= 6f;
						num182 = 4;
					}
					else if (Main.player[projectile.owner].controlDown)
					{
						num181 = Main.player[projectile.owner].position.Y + (float)Main.player[projectile.owner].height + 40f - vector14.Y;
						num180 -= 6f;
						num182 = 4;
					}
				}
				float num183 = (float)Math.Sqrt(num180 * num180 + num181 * num181);
				num183 = (float)Math.Sqrt(num180 * num180 + num181 * num181);
				if (num183 > 800f)
				{
					projectile.position.X = Main.player[projectile.owner].position.X + Main.player[projectile.owner].width / 2 - projectile.width / 2;
					projectile.position.Y = Main.player[projectile.owner].position.Y + Main.player[projectile.owner].height / 2 - projectile.height / 2;
				}
				else if (num183 > num182)
				{
					num183 = num179 / num183;
					num180 *= num183;
					num181 *= num183;
					projectile.velocity.X = num180;
					projectile.velocity.Y = num181;
				}
				else
				{
					projectile.velocity.X = 0f;
					projectile.velocity.Y = 0f;
				}
			}
			else
			{
				projectile.Kill();
			}
        }
    }
}
