using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles
{
    public class CaesiumGas : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Caesium Gas");
        }
        public override void SetDefaults()
        {
            projectile.width = 36;
            projectile.height = 36;
            projectile.aiStyle = -1;
            projectile.penetrate = 1;
            projectile.alpha = 100;
            projectile.friendly = false;
            projectile.timeLeft = 1200;
            projectile.ignoreWater = true;
            projectile.hostile = true;
            projectile.tileCollide = false;
        }

        public override void AI()
        {
            projectile.velocity *= 0.98f;
            if (Main.rand.Next(250) == 0)
            {
                for (int i = 0; i < 3; i++)
                {
                    int d = Dust.NewDust(projectile.position, 8, 8, ModContent.DustType<Dusts.CaesiumDust>());
                    Main.dust[d].velocity.X = Main.rand.NextFloat(-2f, 2f);
                    Main.dust[d].velocity.Y = Main.rand.NextFloat(-2f, 2f);
                }
            }
            foreach (Player p in Main.player)
            {
                if (p.active && !p.dead)
                {
                    if (p.getRect().Intersects(projectile.getRect()))
                    {
                        p.AddBuff(ModContent.BuffType<Buffs.CaesiumPoison>(), 5 * 60);
                    }
                }
            }
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            return false;
        }
        //public override void OnHitPlayer(Player target, int damage, bool crit)
        //{
        //    target.AddBuff(ModContent.BuffType<Buffs.CaesiumPoison>(), 5 * 60);
        //}
    }
}
