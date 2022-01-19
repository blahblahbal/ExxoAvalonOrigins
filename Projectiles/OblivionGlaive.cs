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
            for (int num9 = 0; num9 < 3; num9++)
            {
                Vector2 vector = new Vector2(target.position.X + target.width * 0.5f + Main.rand.Next(201) * -target.direction + (Main.mouseX + Main.screenPosition.X - target.position.X), target.Center.Y - 600f);
                vector.X = (vector.X + target.Center.X) / 2f + Main.rand.Next(-200, 201);
                vector.Y -= 100 * num9;
                float num311 = target.position.X - vector.X;
                float num312 = Main.mouseY + Main.screenPosition.Y - vector.Y;
                float ai2 = num312 + vector.Y;
                if (num312 < 0f)
                {
                    num312 *= -1f;
                }
                if (num312 < 20f)
                {
                    num312 = 20f;
                }
                float num313 = (float)Math.Sqrt(num311 * num311 + num312 * num312);
                num313 = 20f / num313;
                num311 *= num313;
                num312 *= num313;
                Vector2 vector3 = new Vector2(num311, num312) / 2f;
                int p = Projectile.NewProjectile(vector.X, vector.Y, vector3.X, vector3.Y, ModContent.ProjectileType<OblivionGlaiveSky>(), projectile.damage, projectile.knockBack, projectile.owner, 0f, ai2);
                Main.projectile[p].owner = projectile.owner;
                Main.projectile[p].rotation = (float)Math.Atan2(vector.Y - target.Center.Y, vector.X - target.Center.X) - 0.78539816f;
            }
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
