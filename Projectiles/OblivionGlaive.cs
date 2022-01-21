using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles
{
    public class OblivionGlaive : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Oblivion Glaive");
        }
        public override void SetDefaults()
        {
            projectile.width = 18;
            projectile.height = 18;
            projectile.aiStyle = 19;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.tileCollide = false;
            projectile.scale = 1.1f;
            projectile.hide = true;
            projectile.ownerHitCheck = true;
            projectile.melee = true;
        }
        public float movementFactor
        {
            get => projectile.ai[0];
            set => projectile.ai[0] = value;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            int offset = Main.rand.Next(-200, 200);
            Vector2 spawnPosition = new Vector2(target.Center.X + offset, target.Center.Y - 700);
            Vector2 velocity = Vector2.Normalize(target.Center - spawnPosition) * 15f;

            int p = Projectile.NewProjectile(spawnPosition.X, spawnPosition.Y, velocity.X, velocity.Y, ModContent.ProjectileType<Projectiles.OblivionGlaiveSky>(), damage, knockback, projectile.owner, 0f);
            Main.projectile[p].owner = projectile.owner;
        }
        public override void AI()
        {
            Player projOwner = Main.player[projectile.owner];
            Vector2 ownerMountedCenter = projOwner.RotatedRelativePoint(projOwner.MountedCenter, true);
            projectile.direction = projOwner.direction;
            projOwner.heldProj = projectile.whoAmI;
            projOwner.itemTime = projOwner.itemAnimation;
            projectile.position.X = ownerMountedCenter.X - (float)(projectile.width / 2);
            projectile.position.Y = ownerMountedCenter.Y - (float)(projectile.height / 2);
            if (!projOwner.frozen)
            {
                if (movementFactor == 0f)
                {
                    movementFactor = 3f;
                    projectile.netUpdate = true;
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
            projectile.position += projectile.velocity * movementFactor;
            if (projOwner.itemAnimation == 0)
            {
                projectile.Kill();
            }
            projectile.rotation = projectile.velocity.ToRotation() + MathHelper.ToRadians(135f);
            if (projectile.spriteDirection == -1)
            {
                projectile.rotation -= MathHelper.ToRadians(90f);
            }
            var num314 = Dust.NewDust(projectile.position - projectile.velocity * 3f, projectile.width, projectile.height, DustID.Enchanted_Pink, projectile.velocity.X * 0.4f, projectile.velocity.Y * 0.4f, 140, default(Color), 1f);
            Main.dust[num314].noGravity = true;
            Main.dust[num314].fadeIn = 1.25f;
            Main.dust[num314].velocity *= 0.25f;
            var num315 = Dust.NewDust(projectile.position - projectile.velocity * 3f, projectile.width, projectile.height, DustID.Ash, projectile.velocity.X * 0.4f, projectile.velocity.Y * 0.4f, 140, default(Color), 1f);
            Main.dust[num315].noGravity = true;
            Main.dust[num315].fadeIn = 1.25f;
            Main.dust[num315].velocity *= 0.25f;
        }
    }
}
