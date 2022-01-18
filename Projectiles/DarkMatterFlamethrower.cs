using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles
{
    public class DarkMatterFlamethrower : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dark Matter Flamethrower");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Projectiles/DarkMatterFlamethrower");
            projectile.width = dims.Width;
            projectile.height = dims.Height / Main.projFrames[projectile.type];
            projectile.aiStyle = -1;
            projectile.tileCollide = true;
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.timeLeft = 60;
            projectile.light = 1f;
            projectile.penetrate = -1;
            projectile.alpha = 255;
            projectile.magic = true;
            projectile.ignoreWater = true;
        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            if (Main.rand.Next(2) == 0) target.AddBuff(ModContent.BuffType<Buffs.DarkInferno>(), 120);
        }
        public override void AI()
        {
            if (projectile.timeLeft > 60)
            {
                projectile.timeLeft = 60;
            }
            if (projectile.ai[0] > 7f)
            {
                float num314 = 1f;
                if (projectile.ai[0] == 8f)
                {
                    num314 = 0.25f;
                }
                else if (projectile.ai[0] == 9f)
                {
                    num314 = 0.5f;
                }
                else if (projectile.ai[0] == 10f)
                {
                    num314 = 0.75f;
                }
                projectile.ai[0] += 1f;
                int num315 = 58;
                if (num315 == 58 || Main.rand.Next(2) == 0)
                {
                    for (int num316 = 0; num316 < 1; num316++)
                    {
                        int num317 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, num315, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 100, default(Color), 1f);
                        if (projectile.type == ModContent.ProjectileType<DarkMatterFlamethrower>()) Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, DustID.Wraith, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 100, default(Color), 1f);
                        if (Main.rand.Next(3) != 0 || (num315 == 75 && Main.rand.Next(3) == 0))
                        {
                            Main.dust[num317].noGravity = true;
                            Main.dust[num317].scale *= 3f;
                            Dust expr_EA42_cp_0 = Main.dust[num317];
                            expr_EA42_cp_0.velocity.X = expr_EA42_cp_0.velocity.X * 2f;
                            Dust expr_EA62_cp_0 = Main.dust[num317];
                            expr_EA62_cp_0.velocity.Y = expr_EA62_cp_0.velocity.Y * 2f;
                        }
                        if (projectile.type == ModContent.ProjectileType<DarkMatterFlamethrower>())
                        {
                            if (Main.rand.Next(3) != 0 || (num315 == 58 && Main.rand.Next(3) == 0))
                            {
                                Main.dust[num317].noGravity = true;
                                Main.dust[num317].scale *= 3f;
                                Dust expr_EA42_cp_0 = Main.dust[num317];
                                expr_EA42_cp_0.velocity.X = expr_EA42_cp_0.velocity.X * 2f;
                                Dust expr_EA62_cp_0 = Main.dust[num317];
                                expr_EA62_cp_0.velocity.Y = expr_EA62_cp_0.velocity.Y * 2f;
                            }
                        }
                        Main.dust[num317].scale *= 1.5f;
                        Dust expr_EAC7_cp_0 = Main.dust[num317];
                        expr_EAC7_cp_0.velocity.X = expr_EAC7_cp_0.velocity.X * 1.2f;
                        Dust expr_EAE7_cp_0 = Main.dust[num317];
                        expr_EAE7_cp_0.velocity.Y = expr_EAE7_cp_0.velocity.Y * 1.2f;
                        Main.dust[num317].scale *= num314;
                    }
                }
            }
            else
            {
                projectile.ai[0] += 1f;
            }
            projectile.rotation += 0.3f * (float)projectile.direction;
        }
    }
}