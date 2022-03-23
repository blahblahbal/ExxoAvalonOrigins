using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles.Melee
{
    public class OblivionGlaiveSky : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Oblivion Shadow Glaive");
        }
        public override void SetDefaults()
        {
            projectile.width = 20;
            projectile.height = 20;
            projectile.aiStyle = 27;
            projectile.melee = true;
            projectile.penetrate = 1;
            projectile.friendly = true;
            projectile.scale = 1f;
            projectile.tileCollide = false;
            projectile.timeLeft = 360;
            projectile.usesLocalNPCImmunity = true;
            //projectile.localNPCHitCooldown = 40;
            projectile.extraUpdates = 1;
        }
        public override void AI()
        {
            projectile.scale = 1f;
            projectile.alpha = 80;
            if (projectile.position.HasNaNs())
            {
                projectile.Kill();
                return;
            }
            bool num220 = WorldGen.SolidTile(Framing.GetTileSafely((int)projectile.position.X / 16, (int)projectile.position.Y / 16));
            var num315 = Dust.NewDust(projectile.position - projectile.velocity * 3f, projectile.width, projectile.height, DustID.Ash, projectile.velocity.X * 0.4f, projectile.velocity.Y * 0.4f, 140, default(Color), 1.2f);
            Main.dust[num315].noGravity = true;
            Main.dust[num315].fadeIn = 1.25f;
            Main.dust[num315].velocity *= 0.25f;
            if (num220)
            {
                Main.dust[num315].noLight = true;
            }

            //fuck this bullshit ass doodoo vanilla code red sucks ass gonna use and aistyle instead

            //projectile.spriteDirection = projectile.direction = (projectile.velocity.X > 0).ToDirectionInt();

            //projectile.rotation = projectile.velocity.ToRotation() + (projectile.spriteDirection == 1 ? 0f : MathHelper.Pi);
            /*if (projectile.spriteDirection == 1) 
            {
                drawOriginOffsetX = -30;
                drawOriginOffsetY = -28;
                drawOffsetX = -58;
            }
            else
            {
                drawOriginOffsetX = -30;
                drawOriginOffsetY = -28;
                drawOffsetX = 0;
            }*/
        }
        public override void Kill(int timeLeft)
        {
            Vector2 usePos = projectile.position;

            Vector2 rotVector = (projectile.rotation - MathHelper.ToRadians(45f)).ToRotationVector2();
            usePos += rotVector * 20f;

            const int NUM_DUSTS = 25;

            for (int i = 0; i < NUM_DUSTS; i++)
            {
                Dust dust = Dust.NewDustDirect(usePos, projectile.width, projectile.height, DustID.Ash, projectile.velocity.X, projectile.velocity.Y, 80, default(Color), 2f);
                dust.position = (dust.position + projectile.Center) / 2f;
                dust.fadeIn = 1.25f;
                dust.velocity += rotVector * 2f;
                dust.velocity *= 0.5f;
                dust.noGravity = true;
                usePos -= rotVector * 10f;
            }
        }
    }
}
