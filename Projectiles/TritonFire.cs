using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles;

public class TritonFire : ModProjectile
{
    public override string Texture => "Terraria/Projectile_" + ProjectileID.Flames;
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Triton Fire");
    }
    public override void SetDefaults()
    {
        Projectile.width = 6;
        Projectile.height = 6;
        Projectile.alpha = 255;
        Projectile.friendly = true;
        Projectile.hostile = false;
        Projectile.penetrate = 5;
        Projectile.timeLeft = 60;
        Projectile.ignoreWater = false;
        Projectile.tileCollide = true;
        Projectile.DamageType = DamageClass.Ranged;
        Projectile.extraUpdates = 2;
        Projectile.usesIDStaticNPCImmunity = true;
        Projectile.idStaticNPCHitCooldown = 10;
    }
    public override void AI()
    {
        if (Projectile.ai[0] > 1f)
        {
            float num418 = 1f;
            if (Projectile.ai[0] == 8f)
            {
                num418 = 0.25f;
            }
            else if (Projectile.ai[0] == 9f)
            {
                num418 = 0.5f;
            }
            else if (Projectile.ai[0] == 10f)
            {
                num418 = 0.75f;
            }
            Projectile.ai[0] += 1f;
            int num419 = ModContent.DustType<Dusts.TritanoriumFlame>();
            if (num419 == ModContent.DustType<Dusts.TritanoriumFlame>() || Main.rand.Next(3) == 0)
            {
                for (int num420 = 0; num420 < 1; num420++)
                {
                    int num421 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, num419, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f, 50, default, 0.7f);
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
                    if (Projectile.type == 188)
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
                int num161 = Gore.NewGore(new Vector2(Projectile.position.X, Projectile.position.Y), default(Vector2), Main.rand.Next(61, 64));
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
            Projectile.ai[0] += 1f;
        }
        Projectile.rotation += 0.3f * (float)Projectile.direction;
    }
    public override bool OnTileCollide(Vector2 oldVelocity)
    {
        Projectile.NewProjectile(new Vector2(Projectile.Center.X, Projectile.Center.Y), new Vector2(0f, 0f), ModContent.ProjectileType<Projectiles.TritonFireLinger>(), Projectile.damage, Projectile.knockBack, Projectile.owner);
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
        Projectile.width = 20;
        Projectile.height = 20;
        Projectile.alpha = 255;
        Projectile.friendly = true;
        Projectile.hostile = false;
        Projectile.penetrate = -1;
        Projectile.timeLeft = 300 + Main.rand.Next(50, 100);
        Projectile.ignoreWater = false;
        Projectile.tileCollide = false;
        Projectile.DamageType = DamageClass.Ranged;
        Projectile.usesIDStaticNPCImmunity = true;
        Projectile.idStaticNPCHitCooldown = 10;
    }
    public override void AI()
    {
        for (int i = 0; i < 1; i++)
        {
            int num421 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, ModContent.DustType<Dusts.TritanoriumFlame>(), Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f, 50, default, 2.2f);
            Main.dust[num421].velocity.X *= 1f;
            Main.dust[num421].velocity.Y *= 1.5f;
            Main.dust[num421].noGravity = true;
        }
        if (Main.rand.Next(40) == 1)
        {
            int randomSize = Main.rand.Next(1, 4) / 2;
            int num161 = Gore.NewGore(new Vector2(Projectile.position.X, Projectile.position.Y), default(Vector2), Main.rand.Next(61, 64));
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