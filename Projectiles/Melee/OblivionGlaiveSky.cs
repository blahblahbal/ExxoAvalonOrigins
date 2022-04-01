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
            Projectile.width = 20;
            Projectile.height = 20;
            Projectile.aiStyle = 27;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.penetrate = 1;
            Projectile.friendly = true;
            Projectile.scale = 1f;
            Projectile.tileCollide = false;
            Projectile.timeLeft = 360;
            Projectile.usesLocalNPCImmunity = true;
            //projectile.localNPCHitCooldown = 40;
            Projectile.extraUpdates = 1;
        }
        public override void AI()
        {
            Projectile.scale = 1f;
            Projectile.alpha = 80;
            if (Projectile.position.HasNaNs())
            {
                Projectile.Kill();
                return;
            }
            bool num220 = WorldGen.SolidTile(Framing.GetTileSafely((int)Projectile.position.X / 16, (int)Projectile.position.Y / 16));
            var num315 = Dust.NewDust(Projectile.position - Projectile.velocity * 3f, Projectile.width, Projectile.height, DustID.Ash, Projectile.velocity.X * 0.4f, Projectile.velocity.Y * 0.4f, 140, default(Color), 1.2f);
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
                DrawOriginOffsetY = -28;
                DrawOffsetX = -58;
            }
            else
            {
                drawOriginOffsetX = -30;
                DrawOriginOffsetY = -28;
                DrawOffsetX = 0;
            }*/
        }
        public override void Kill(int timeLeft)
        {
            Vector2 usePos = Projectile.position;

            Vector2 rotVector = (Projectile.rotation - MathHelper.ToRadians(45f)).ToRotationVector2();
            usePos += rotVector * 20f;

            const int NUM_DUSTS = 25;

            for (int i = 0; i < NUM_DUSTS; i++)
            {
                Dust dust = Dust.NewDustDirect(usePos, Projectile.width, Projectile.height, DustID.Ash, Projectile.velocity.X, Projectile.velocity.Y, 80, default(Color), 2f);
                dust.position = (dust.position + Projectile.Center) / 2f;
                dust.fadeIn = 1.25f;
                dust.velocity += rotVector * 2f;
                dust.velocity *= 0.5f;
                dust.noGravity = true;
                usePos -= rotVector * 10f;
            }
        }
    }
}
