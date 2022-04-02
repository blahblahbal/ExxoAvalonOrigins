using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles;

public class DarkMatterFlamethrower : ModProjectile
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Dark Matter Flamethrower");
    }

    public override void SetDefaults()
    {
        Rectangle dims = ExxoAvalonOrigins.GetDims("Projectiles/DarkMatterFlamethrower");
        Projectile.width = dims.Width;
        Projectile.height = dims.Height / Main.projFrames[Projectile.type];
        Projectile.aiStyle = -1;
        Projectile.tileCollide = true;
        Projectile.friendly = false;
        Projectile.hostile = true;
        Projectile.timeLeft = 60;
        Projectile.light = 1f;
        Projectile.penetrate = -1;
        Projectile.alpha = 255;
        Projectile.DamageType = DamageClass.Magic;
        Projectile.ignoreWater = true;
    }
    public override void OnHitPlayer(Player target, int damage, bool crit)
    {
        if (Main.rand.Next(2) == 0) target.AddBuff(ModContent.BuffType<Buffs.DarkInferno>(), 120);
    }
    public override void AI()
    {
        if (Projectile.timeLeft > 60)
        {
            Projectile.timeLeft = 60;
        }
        if (Projectile.ai[0] > 7f)
        {
            float num314 = 1f;
            if (Projectile.ai[0] == 8f)
            {
                num314 = 0.25f;
            }
            else if (Projectile.ai[0] == 9f)
            {
                num314 = 0.5f;
            }
            else if (Projectile.ai[0] == 10f)
            {
                num314 = 0.75f;
            }
            Projectile.ai[0] += 1f;
            int num315 = 58;
            if (num315 == 58 || Main.rand.Next(2) == 0)
            {
                for (int num316 = 0; num316 < 1; num316++)
                {
                    int num317 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, num315, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f, 100, default(Color), 1f);
                    if (Projectile.type == ModContent.ProjectileType<DarkMatterFlamethrower>()) Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.Wraith, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f, 100, default(Color), 1f);
                    if (Main.rand.Next(3) != 0 || (num315 == 75 && Main.rand.Next(3) == 0))
                    {
                        Main.dust[num317].noGravity = true;
                        Main.dust[num317].scale *= 3f;
                        Dust expr_EA42_cp_0 = Main.dust[num317];
                        expr_EA42_cp_0.velocity.X = expr_EA42_cp_0.velocity.X * 2f;
                        Dust expr_EA62_cp_0 = Main.dust[num317];
                        expr_EA62_cp_0.velocity.Y = expr_EA62_cp_0.velocity.Y * 2f;
                    }
                    if (Projectile.type == ModContent.ProjectileType<DarkMatterFlamethrower>())
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
            Projectile.ai[0] += 1f;
        }
        Projectile.rotation += 0.3f * (float)Projectile.direction;
    }
}