using Terraria;
using Terraria.ID;

namespace ExxoAvalonOrigins.Projectiles.Summon
{
    public class UltraHMinion : HoverShooter
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 4;
            Main.projPet[Projectile.type] = true;
            ProjectileID.Sets.MinionSacrificable[Projectile.type] = true;
            ProjectileID.Sets.Homing[Projectile.type] = true;
            ProjectileID.Sets.MinionTargettingFeature[Projectile.type] = true;
        }

        public override void SetDefaults()
        {
            Projectile.netImportant = true;
            Projectile.width = 50;
            Projectile.height = 50;
            Projectile.friendly = true;
            Projectile.minion = true;
            Projectile.minionSlots = 0.25f;
            Projectile.penetrate = -1;
            Projectile.timeLeft *= 5;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
        }

        public override void CheckActive()
        {
            Player player = Main.player[Projectile.owner];
            ExxoAvalonOriginsModPlayer modPlayer = player.Avalon();
            if (player.dead)
            {
                modPlayer.UltraHMinion = false;
            }
            if (modPlayer.UltraHMinion)
            {
                Projectile.timeLeft = 2;
            }
        }

        public override void SelectFrame()
        {
            Projectile.frameCounter++;
            if (Projectile.frameCounter >= 8)
            {
                Projectile.frameCounter = 0;
                Projectile.frame = (Projectile.frame + 1) % 3;
            }
        }
    }
}
