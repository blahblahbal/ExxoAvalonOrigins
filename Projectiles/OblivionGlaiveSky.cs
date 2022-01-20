using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles
{
    public class OblivionGlaiveSky : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Oblivion Sky Glaive");
        }
        public override void SetDefaults()
        {
            projectile.width = 40;
            projectile.height = 40;
            projectile.Hitbox = new Rectangle(100, 100, 40, 40);
            projectile.aiStyle = -1;
            projectile.melee = true;
            projectile.penetrate = -1;
            projectile.friendly = true;
            projectile.scale = 1f;
            projectile.tileCollide = false;
            projectile.timeLeft = 360;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 40;
        }
        public override void AI()
        {
            if (projectile.position.HasNaNs())
            {
                projectile.Kill();
                return;
            }
            bool num220 = WorldGen.SolidTile(Framing.GetTileSafely((int)projectile.position.X / 16, (int)projectile.position.Y / 16));
            Dust dust2 = Main.dust[Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), (int)(projectile.width * projectile.scale), (int)(projectile.height * projectile.scale), DustID.Enchanted_Pink)];

            dust2.position = new Vector2(projectile.position.X + (projectile.width - 0.5f * projectile.scale), projectile.position.Y + (projectile.height - 0.5f * projectile.scale));
            dust2.velocity = Vector2.Zero;
            dust2.scale = 1.5f;
            dust2.noGravity = true;
            if (num220)
            {
                dust2.noLight = true;
            }
        }
    }
}
