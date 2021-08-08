using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;namespace ExxoAvalonOrigins.Projectiles{
    public class BlahBulletOffspring : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blah Bullet");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Projectiles/BlahBulletOffspring");
            projectile.width = dims.Width * 4 / 20;
            projectile.height = dims.Height * 4 / 20 / Main.projFrames[projectile.type];
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.penetrate = 1;
            projectile.light = 0.8f;
            projectile.alpha = 255;
            projectile.MaxUpdates = 2;
            projectile.scale = 1f;
            projectile.timeLeft = 600;
            projectile.ranged = true;
        }        public override void Kill(int timeLeft)
        {
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 14);
            for (int num200 = 0; num200 < 7; num200++)
            {
                Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 31, 0f, 0f, 100, default(Color), 1.5f);
            }
            for (int num201 = 0; num201 < 3; num201++)
            {
                int num202 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, 0f, 0f, 100, default(Color), 2.5f);
                Main.dust[num202].noGravity = true;
                Main.dust[num202].velocity *= 3f;
                num202 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, 0f, 0f, 100, default(Color), 1.5f);
                Main.dust[num202].velocity *= 2f;
            }
            int num203 = Gore.NewGore(new Vector2(projectile.position.X - 10f, projectile.position.Y - 10f), default(Vector2), Main.rand.Next(61, 64), 1f);
            Main.gore[num203].velocity *= 0.3f;
            Gore expr_639C_cp_0 = Main.gore[num203];
            expr_639C_cp_0.velocity.X = expr_639C_cp_0.velocity.X + (float)Main.rand.Next(-10, 11) * 0.05f;
            Gore expr_63CA_cp_0 = Main.gore[num203];
            expr_63CA_cp_0.velocity.Y = expr_63CA_cp_0.velocity.Y + (float)Main.rand.Next(-10, 11) * 0.05f;
            if (projectile.owner == Main.myPlayer)
            {
                projectile.localAI[1] = -1f;
                projectile.maxPenetrate = 0;
                projectile.position.X = projectile.position.X + (float)(projectile.width / 2);
                projectile.position.Y = projectile.position.Y + (float)(projectile.height / 2);
                projectile.width = 80;
                projectile.height = 80;
                projectile.position.X = projectile.position.X - (float)(projectile.width / 2);
                projectile.position.Y = projectile.position.Y - (float)(projectile.height / 2);
                projectile.Damage();
            }
        }        public override void AI()        {            projectile.ai[0] += 1f;            if (projectile.alpha < 170)            {                for (var num26 = 0; num26 < 10; num26++)                {                    var x2 = projectile.position.X - projectile.velocity.X / 10f * num26;                    var y2 = projectile.position.Y - projectile.velocity.Y / 10f * num26;                    int num27;                    num27 = Dust.NewDust(new Vector2(x2, y2), 1, 1, 6, 0f, 0f, 0, default(Color), 1f);                    Main.dust[num27].alpha = projectile.alpha;                    Main.dust[num27].position.X = x2;                    Main.dust[num27].position.Y = y2;                    Main.dust[num27].velocity *= 0f;                    Main.dust[num27].noGravity = true;                }            }            var num28 = (float)Math.Sqrt(projectile.velocity.X * projectile.velocity.X + projectile.velocity.Y * projectile.velocity.Y);            var num29 = projectile.localAI[0];            if (num29 == 0f)            {                projectile.localAI[0] = num28;                num29 = num28;            }            if (projectile.alpha > 0)            {                projectile.alpha -= 25;            }            if (projectile.alpha < 0)            {                projectile.alpha = 0;            }            var num30 = projectile.position.X;            var num31 = projectile.position.Y;            var num32 = 300f;            var flag = false;            var num33 = 0;            if (projectile.ai[1] == 0f)            {                for (var num34 = 0; num34 < 200; num34++)                {                    if (Main.npc[num34].active && !Main.npc[num34].dontTakeDamage && !Main.npc[num34].friendly && Main.npc[num34].lifeMax > 5 && (projectile.ai[1] == 0f || projectile.ai[1] == num34 + 1))                    {                        var num35 = Main.npc[num34].position.X + Main.npc[num34].width / 2;                        var num36 = Main.npc[num34].position.Y + Main.npc[num34].height / 2;                        var num37 = Math.Abs(projectile.position.X + projectile.width / 2 - num35) + Math.Abs(projectile.position.Y + projectile.height / 2 - num36);                        if (num37 < num32 && Collision.CanHit(new Vector2(projectile.position.X + projectile.width / 2, projectile.position.Y + projectile.height / 2), 1, 1, Main.npc[num34].position, Main.npc[num34].width, Main.npc[num34].height))                        {                            num32 = num37;                            num30 = num35;                            num31 = num36;                            flag = true;                            num33 = num34;                        }                    }                }                if (flag)                {                    projectile.ai[1] = num33 + 1;                }                flag = false;            }            if (projectile.ai[1] != 0f)            {                var num38 = (int)(projectile.ai[1] - 1f);                if (Main.npc[num38].active)                {                    var num39 = Main.npc[num38].position.X + Main.npc[num38].width / 2;                    var num40 = Main.npc[num38].position.Y + Main.npc[num38].height / 2;                    var num41 = Math.Abs(projectile.position.X + projectile.width / 2 - num39) + Math.Abs(projectile.position.Y + projectile.height / 2 - num40);                    if (num41 < 1000f)                    {                        flag = true;                        num30 = Main.npc[num38].position.X + Main.npc[num38].width / 2;                        num31 = Main.npc[num38].position.Y + Main.npc[num38].height / 2;                    }                }            }            if (flag)            {                var num42 = num29;                var vector = new Vector2(projectile.position.X + projectile.width * 0.5f, projectile.position.Y + projectile.height * 0.5f);                var num43 = num30 - vector.X;                var num44 = num31 - vector.Y;                var num45 = (float)Math.Sqrt(num43 * num43 + num44 * num44);                num45 = num42 / num45;                num43 *= num45;                num44 *= num45;                var num46 = 8;                projectile.velocity.X = (projectile.velocity.X * (num46 - 1) + num43) / num46;                projectile.velocity.Y = (projectile.velocity.Y * (num46 - 1) + num44) / num46;            }            projectile.rotation = (float)Math.Atan2(projectile.velocity.Y, projectile.velocity.X) + 1.57f;            if (projectile.velocity.Y > 16f)            {                projectile.velocity.Y = 16f;            }        }    }}