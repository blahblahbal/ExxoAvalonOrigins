using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;namespace ExxoAvalonOrigins.Projectiles{	public class LightningBolt : ModProjectile	{		public override void SetStaticDefaults()		{			DisplayName.SetDefault("Lightning");		}		public override void SetDefaults()		{			projectile.width = 8;			projectile.height = 8;			projectile.scale = 1f;			projectile.alpha = 100;			projectile.aiStyle = -1;			projectile.timeLeft = 50;			projectile.friendly = true;			projectile.penetrate = 1;			projectile.light = 1f;			projectile.ignoreWater = true;			projectile.tileCollide = false;		}        public override void AI()        {            if (projectile.scale == 1.0)
            {
                projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X);
                if (Main.time % 6 <= 1 && Main.netMode != 1)
                {
                    int num54 = Projectile.NewProjectile(projectile.position, Vector2.Zero, ModContent.ProjectileType<Projectiles.LightningTrail>(), 60, 0f, projectile.owner);
                    Main.projectile[num54].rotation = projectile.rotation;
                    Main.projectile[num54].timeLeft = projectile.timeLeft;
                    projectile.rotation += (Main.rand.Next(200) - 100) / 100f;
                    projectile.velocity.Y = (float)Math.Sin(projectile.rotation) * 10;
                    projectile.velocity.X = (float)Math.Cos(projectile.rotation) * 10;
                }
            }
            if (((Main.rand.Next(15) == 0 && projectile.ai[0] > 0) || projectile.scale == 1.0) && projectile.scale > 0.4f)
            {
                int num54 = Projectile.NewProjectile(projectile.position, Vector2.Zero, ModContent.ProjectileType<Projectiles.LightningBolt>(), 80, 0f, projectile.owner);
                Main.projectile[num54].scale = projectile.scale * (Main.rand.Next(100) / 100f);
                Main.projectile[num54].rotation = projectile.rotation + (Main.rand.Next(200) - 100) / 100f;
                Main.projectile[num54].timeLeft = projectile.timeLeft;
                Main.projectile[num54].position.X += (float)Math.Cos(projectile.rotation) * Main.projectile[num54].scale * 48;
                Main.projectile[num54].position.Y += (float)Math.Sin(projectile.rotation) * Main.projectile[num54].scale * 48;
                Main.projectile[num54].position.X += (float)Math.Cos(Main.projectile[num54].rotation) * Main.projectile[num54].scale * 48;
                Main.projectile[num54].position.Y += (float)Math.Sin(Main.projectile[num54].rotation) * Main.projectile[num54].scale * 48;
                Main.projectile[num54].ai[0] = 10;
            }
            projectile.ai[0]--;
            projectile.alpha = 255 - (projectile.timeLeft * 2) - (int)(25 * projectile.scale);
            if (projectile.alpha < 100) projectile.alpha = 0;
            //if (Main.tileSolid[Main.tile[(int)(projectile.position.X / 16f), (int)(projectile.position.Y / 16f)].type] && Main.tile[(int)(projectile.position.X / 16f), (int)(projectile.position.Y / 16f)].active)
            if (!Main.tile[(int)(projectile.position.X / 16f), (int)(projectile.position.Y / 16f)].inActive())
            {
                projectile.tileCollide = true;
            }        }    }}