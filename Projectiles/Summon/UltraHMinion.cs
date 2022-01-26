using Terraria;
using Terraria.ID;

namespace ExxoAvalonOrigins.Projectiles.Summon
{
    public class UltraHMinion : HoverShooter
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[projectile.type] = 4;
            Main.projPet[projectile.type] = true;
            ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
            ProjectileID.Sets.Homing[projectile.type] = true;
            ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true;
        }

        public override void SetDefaults()
        {
            projectile.netImportant = true;
            projectile.width = 50;
            projectile.height = 50;
            projectile.friendly = true;
            projectile.minion = true;
            projectile.minionSlots = 0.25f;
            projectile.penetrate = -1;
            projectile.timeLeft *= 5;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
        }

        public override void CheckActive()
        {
            Player player = Main.player[projectile.owner];
            ExxoAvalonOriginsModPlayer modPlayer = player.Avalon();
            if (player.dead)
            {
                modPlayer.UltraHMinion = false;
            }
            if (modPlayer.UltraHMinion)
            {
                projectile.timeLeft = 2;
            }
        }

        public override void SelectFrame()
        {
            projectile.frameCounter++;
            if (projectile.frameCounter >= 8)
            {
                projectile.frameCounter = 0;
                projectile.frame = (projectile.frame + 1) % 3;
            }
        }
    }
}
