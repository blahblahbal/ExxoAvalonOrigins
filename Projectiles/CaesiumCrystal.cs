using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;namespace ExxoAvalonOrigins.Projectiles{	public class CaesiumCrystal : ModProjectile	{		public override void SetStaticDefaults()		{			DisplayName.SetDefault("Caesium Crystal");		}		public override void SetDefaults()		{			Rectangle dims = ExxoAvalonOrigins.getDims("Projectiles/CaesiumCrystal");			projectile.width = dims.Width;			projectile.height = dims.Height / Main.projFrames[projectile.type];			projectile.aiStyle = -1;			projectile.tileCollide = true;			projectile.friendly = false;            projectile.hostile = true;			projectile.timeLeft = 540;			projectile.light = 1f;			projectile.penetrate = -1;			projectile.magic = true;			projectile.ignoreWater = true;		}        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 10);
            projectile.ai[0] += 1f;
            if (projectile.ai[0] >= 2f)
            {
                projectile.position += projectile.velocity;
                projectile.Kill();
            }
            else
            {
                if (projectile.velocity.Y != oldVelocity.Y)
                {
                    projectile.velocity.Y = -oldVelocity.Y;
                }
                if (projectile.velocity.X != oldVelocity.X)
                {
                    projectile.velocity.X = -oldVelocity.X;
                }
            }
            return false;
        }        public override void AI()        {            var num924 = Dust.NewDust(new Vector2(projectile.position.X + projectile.velocity.X, projectile.position.Y + projectile.velocity.Y), projectile.width, projectile.height, ModContent.DustType<Dusts.CaesiumDust>(), projectile.velocity.X, projectile.velocity.Y, 100, default, 1f);            Main.dust[num924].noGravity = true;            if (Main.rand.Next(10) == 0)            {                num924 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, ModContent.DustType<Dusts.CaesiumDust>(), projectile.velocity.X, projectile.velocity.Y, 100, default, 1.4f);            }            if (projectile.ai[1] >= 20f)            {                projectile.velocity.Y = projectile.velocity.Y + 0.2f;            }            projectile.rotation += 0.3f * projectile.direction;            if (projectile.velocity.Y > 16f)            {                projectile.velocity.Y = 16f;                return;            }        }    }}