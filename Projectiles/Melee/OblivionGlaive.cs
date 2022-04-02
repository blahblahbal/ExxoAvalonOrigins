using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles.Melee;

public class OblivionGlaive : ModProjectile
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Oblivion Glaive");
    }
    public override void SetDefaults()
    {
        Projectile.width = 18;
        Projectile.height = 18;
        Projectile.aiStyle = 19;
        Projectile.friendly = true;
        Projectile.penetrate = -1;
        Projectile.tileCollide = false;
        Projectile.scale = 1.1f;
        Projectile.hide = true;
        Projectile.ownerHitCheck = true;
        Projectile.DamageType = DamageClass.Melee;
    }
    public float movementFactor
    {
        get => Projectile.ai[0];
        set => Projectile.ai[0] = value;
    }
    public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
    {
        int offset = Main.rand.Next(-200, 200);
        Vector2 spawnPosition = new Vector2(target.Center.X + offset, target.Center.Y - 700);
        Vector2 velocity = Vector2.Normalize(target.Center - spawnPosition) * 15f;

        int p = Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(), spawnPosition.X, spawnPosition.Y, velocity.X, velocity.Y, ModContent.ProjectileType<Projectiles.Melee.OblivionGlaiveSky>(), damage, knockback, Projectile.owner, 0f);
        Main.projectile[p].owner = Projectile.owner;
    }
    public override void AI()
    {
        Player projOwner = Main.player[Projectile.owner];
        Vector2 ownerMountedCenter = projOwner.RotatedRelativePoint(projOwner.MountedCenter, true);
        Projectile.direction = projOwner.direction;
        projOwner.heldProj = Projectile.whoAmI;
        projOwner.itemTime = projOwner.itemAnimation;
        Projectile.position.X = ownerMountedCenter.X - (float)(Projectile.width / 2);
        Projectile.position.Y = ownerMountedCenter.Y - (float)(Projectile.height / 2);
        if (!projOwner.frozen)
        {
            if (movementFactor == 0f)
            {
                movementFactor = 3f;
                Projectile.netUpdate = true;
            }
            if (projOwner.itemAnimation < projOwner.itemAnimationMax / 3)
            {
                movementFactor -= 3.8f;
            }
            else
            {
                movementFactor += 3.2f;
            }
        }
        Projectile.position += Projectile.velocity * movementFactor;
        if (projOwner.itemAnimation == 0)
        {
            Projectile.Kill();
        }
        Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.ToRadians(135f);
        if (Projectile.spriteDirection == -1)
        {
            Projectile.rotation -= MathHelper.ToRadians(90f);
        }
        var num314 = Dust.NewDust(Projectile.position - Projectile.velocity * 3f, Projectile.width, Projectile.height, DustID.Enchanted_Pink, Projectile.velocity.X * 0.4f, Projectile.velocity.Y * 0.4f, 140, default(Color), 1f);
        Main.dust[num314].noGravity = true;
        Main.dust[num314].fadeIn = 1.25f;
        Main.dust[num314].velocity *= 0.25f;
        var num315 = Dust.NewDust(Projectile.position - Projectile.velocity * 3f, Projectile.width, Projectile.height, DustID.Ash, Projectile.velocity.X * 0.4f, Projectile.velocity.Y * 0.4f, 140, default(Color), 1f);
        Main.dust[num315].noGravity = true;
        Main.dust[num315].fadeIn = 1.25f;
        Main.dust[num315].velocity *= 0.25f;
    }
}
