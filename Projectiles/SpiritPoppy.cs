using Microsoft.Xna.Framework;using Terraria;using Terraria.ModLoader;using Terraria.ID;

namespace ExxoAvalonOrigins.Projectiles
{
    public class SpiritPoppy : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spirit Poppy");
        }
        public override void SetDefaults()
        {
            projectile.netImportant = true;
            projectile.width = 32;
            projectile.height = 32;
            projectile.aiStyle = -1;
            projectile.penetrate = -1;
            projectile.timeLeft = 10000;
            projectile.magic = true;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
            projectile.friendly = true;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.Kill();
            return false;
        }
        public override void AI()
        {
            if (projectile.velocity.Y == 0f)
            {
                projectile.velocity.X = projectile.velocity.X * 0.99f;
            }
            projectile.rotation += projectile.velocity.X * 0.1f;
            //projectile.velocity.Y = projectile.velocity.Y + 0.2f;
            projectile.ai[0]++;
            if (projectile.ai[0] >= 50 && projectile.ai[0] <= 100)
            {
                projectile.velocity.Y *= 0.8f;
            }
            if (projectile.ai[0] == 101)
            {
                projectile.velocity.Y *= -1;
            }
            if (projectile.ai[0] > 101)
            {
                projectile.velocity.Y *= 1.02f;
            }


            int x = (int)(projectile.position.X / 16);
            int y = (int)(projectile.position.Y / 16);

            if (!Main.tile[x, y].active())
            {
                projectile.tileCollide = true;
            }

            if (projectile.owner == Main.myPlayer)
            {
                int xpos = (int)((projectile.position.X + (float)(projectile.width / 2)) / 16f);
                int ypos = (int)((projectile.position.Y + (float)projectile.height - 4f) / 16f);
                if (Main.tile[xpos, ypos] != null && !Main.tile[xpos, ypos].active())
                {
                    WorldGen.PlaceTile(xpos, ypos, ModContent.TileType<Tiles.SpiritPoppy>(), false, true);
                    if (Main.tile[xpos, ypos].active())
                    {
                        projectile.Kill();
                    }
                }
            }
        }
    }
}
