using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles
{
    class TheSun : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Sun");
        }

        public override void SetDefaults()
        {
            projectile.width = 32;
            projectile.height = 34;
            projectile.alpha = 0;
            projectile.scale = 1.4f;
            projectile.aiStyle = -1;
            aiType = 20;
            projectile.timeLeft = 900;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.damage = 0;
            projectile.light = 2;
            //projectile.ownerHitCheck = true;
            projectile.tileCollide = false;
            projectile.magic = true;
            Main.projFrames[projectile.type] = 4;
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            spriteBatch.End();
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, SamplerState.PointClamp, null, null);
            return true;
        }
        public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            spriteBatch.End();
            spriteBatch.Begin();
        }
        public override void AI()
        {
            projectile.rotation++;
            projectile.scale *= 1.002f;
            if (projectile.scale > 6f) projectile.scale = 6f;
            var v = projectile.Center - new Vector2(projectile.width * projectile.scale / 2f, projectile.height * projectile.scale / 2f);
            var wH = new Vector2(projectile.width * projectile.scale, projectile.height * projectile.scale);
            var value2 = ExxoAvalonOrigins.NewRectVector2(v, wH);
            var npc = Main.npc;
            for (var num57 = 0; num57 < npc.Length; num57++)
            {
                var nPC = npc[num57];
                if (nPC.active && !nPC.dontTakeDamage && !nPC.friendly && nPC.life >= 1 && nPC.getRect().Intersects(value2))
                {
                    if (projectile.ai[0] % 15 == 0) nPC.StrikeNPC(projectile.damage, projectile.knockBack, (nPC.Center.X < projectile.Center.X) ? -1 : 1, false, false);
                }
            }
            if (Main.rand.Next(2) == 0)
            {
                int dust = Dust.NewDust(new Vector2((float)projectile.position.X, (float)projectile.position.Y), projectile.width, projectile.height, DustID.HallowedWeapons, 0, 0, 100, Color.White, 3.0f);
                Main.dust[dust].noGravity = true;
                int dust2 = Dust.NewDust(new Vector2((float)projectile.position.X, (float)projectile.position.Y), projectile.width, projectile.height, DustID.Fire, 0, 0, 100, Color.White, 3.0f);
                Main.dust[dust2].noGravity = true;
            }

            projectile.frameCounter++;
            if (projectile.frameCounter > 2)
            {
                projectile.frame++;
                projectile.frameCounter = 3;
            }
            if (projectile.frame >= 4)
            {
                projectile.frame = 0;
            }
        }
    }
}
