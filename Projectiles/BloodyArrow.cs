using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles
{
    public class BloodyArrow : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bloody Arrow");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.GetDims("Projectiles/BloodyArrow");
            projectile.width = dims.Width * 10 / 32;
            projectile.height = dims.Height * 10 / 32 / Main.projFrames[projectile.type];
            projectile.aiStyle = -1;
            aiType = 636;
            projectile.friendly = true;
            projectile.ranged = true;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            projectile.ai[0] = 1;
            projectile.ai[1] = target.whoAmI;
            projectile.Kill();
            //projectile.velocity *= 0f;
            //projectile.GetGlobalProjectile<ExxoAvalonOriginsGlobalProjectileInstance>().bloodArrowPos = projectile.position;
            target.AddBuff(ModContent.BuffType<Buffs.Bleeding>(), 8 * 60);
            if (target.GetGlobalNPC<ExxoAvalonOriginsGlobalNPCInstance>().bleedStacks < 3)
            {
                target.GetGlobalNPC<ExxoAvalonOriginsGlobalNPCInstance>().bleedStacks++;
            }
        }
        public override void AI()
        {
            projectile.ai[0] += 1f;
            if (projectile.ai[0] >= 15f)
            {
                projectile.ai[0] = 15f;
                projectile.velocity.Y = projectile.velocity.Y + 0.1f;
            }
            projectile.rotation = (float)Math.Atan2(projectile.velocity.Y, projectile.velocity.X) + 1.57f;
            if (projectile.velocity.Y > 16f)
            {
                projectile.velocity.Y = 16f;
            }
        }
    }
}
