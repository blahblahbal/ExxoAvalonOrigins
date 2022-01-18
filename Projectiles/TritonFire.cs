using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles
{
    public class TritonFire : ModProjectile
    {
        public override string Texture => "Terraria/Projectile_" + ProjectileID.Flames;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Triton Fire");
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
                int num419 = ModContent.DustType<Dusts.TritanoriumFlame>();
                if (num419 == ModContent.DustType<Dusts.TritanoriumFlame>() || Main.rand.Next(3) == 0)
                {
                    for (int num420 = 0; num420 < 1; num420++)
                    {
                        int num421 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, num419, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 50, default, 0.7f);
                        Dust dust98;
                        Dust dust189;
                        if (Main.rand.Next(3) != 0 || (num419 == 75 && Main.rand.Next(3) == 0))
                        {
                            Main.dust[num421].noGravity = true;
                            dust98 = Main.dust[num421];
                            dust189 = dust98;
                            dust189.scale *= 3f;
                            Main.dust[num421].velocity.X *= 1.5f;
                            Main.dust[num421].velocity.Y *= 1.5f;
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
                        Main.dust[num421].velocity.X *= 0.8f;
                        Main.dust[num421].velocity.Y *= 0.8f;
                        dust98 = Main.dust[num421];
                        dust189 = dust98;
                        dust189.scale *= num418;
                    }
                }
                if (Main.rand.Next(50) == 1)
                {
                    int randomSize = Main.rand.Next(2, 4) / 2;
                    int num161 = Gore.NewGore(new Vector2(projectile.position.X, projectile.position.Y), default(Vector2), Main.rand.Next(61, 64));
                    Gore gore30 = Main.gore[num161];
                    Gore gore40 = gore30;
                    gore40.velocity *= 0.3f;
                    gore40.scale *= randomSize;
                    Main.gore[num161].velocity.X += Main.rand.Next(-1, 2);
                    Main.gore[num161].velocity.Y += Main.rand.Next(-1, 2);
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
            Projectile.NewProjectile(new Vector2(projectile.Center.X, projectile.Center.Y), new Vector2(0f, 0f), ModContent.ProjectileType<Projectiles.TritonFireLinger>(), projectile.damage, projectile.knockBack, projectile.owner);
            return true;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            //target.AddBuff(BuffID.Frostburn, 240);
        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            //target.AddBuff(BuffID.Frostburn, 240, false);
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
    public class TritonFireLinger : ModProjectile
    {
        public override string Texture => "Terraria/Projectile_" + ProjectileID.Flames;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Triton Fire Linger");
        }
        public override void SetDefaults()
        {
            projectile.width = 20;
            projectile.height = 20;
            projectile.alpha = 255;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.penetrate = -1;
            projectile.timeLeft = 300 + Main.rand.Next(50, 100);
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
                int num421 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, ModContent.DustType<Dusts.TritanoriumFlame>(), projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 50, default, 2.2f);
                Main.dust[num421].velocity.X *= 1f;
                Main.dust[num421].velocity.Y *= 1.5f;
                Main.dust[num421].noGravity = true;
            }
            if (Main.rand.Next(40) == 1)
            {
                int randomSize = Main.rand.Next(1, 4) / 2;
                int num161 = Gore.NewGore(new Vector2(projectile.position.X, projectile.position.Y), default(Vector2), Main.rand.Next(61, 64));
                Gore gore30 = Main.gore[num161];
                Gore gore40 = gore30;
                gore40.velocity *= 0.3f;
                gore40.scale *= randomSize;
                Main.gore[num161].velocity.X += Main.rand.Next(-1, 2);
                Main.gore[num161].velocity.Y += Main.rand.Next(-1, 2);
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
            //target.AddBuff(BuffID.Frostburn, 240);
        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            //target.AddBuff(BuffID.Frostburn, 240, false);
        }
    }
}
