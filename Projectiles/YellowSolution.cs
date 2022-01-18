using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles
{
    public class YellowSolution : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Yellow Spray");
        }
        public override void SetDefaults()
        {
            projectile.width = 6;
            projectile.height = 6;
            projectile.friendly = true;
            projectile.alpha = 255;
            projectile.penetrate = -1;
            projectile.extraUpdates = 2;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
        }
        public override bool? CanCutTiles()
        {
            return false;
        }
        public override void AI()
        {

            int dustType = ModContent.DustType<Dusts.YellowSolutionDust>();

            if (projectile.owner == Main.myPlayer)
                Convert((int)(projectile.position.X + projectile.width / 2) / 16, (int)(projectile.position.Y + projectile.height / 2) / 16, 2);

            if (projectile.timeLeft > 133)
                projectile.timeLeft = 133;

            if (projectile.ai[0] > 7f)
            {
                float dustScale = 1f;

                if (projectile.ai[0] == 8f)
                    dustScale = 0.2f;
                else if (projectile.ai[0] == 9f)
                    dustScale = 0.4f;
                else if (projectile.ai[0] == 10f)
                    dustScale = 0.6f;
                else if (projectile.ai[0] == 11f)
                    dustScale = 0.8f;

                projectile.ai[0] += 1f;

                for (int i = 0; i < 1; i++)
                {
                    int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, dustType, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 100);
                    Dust dust = Main.dust[dustIndex];
                    dust.noGravity = true;
                    dust.scale *= 1.75f;
                    dust.velocity.X *= 2f;
                    dust.velocity.Y *= 2f;
                    dust.scale *= dustScale;
                }
            }
            else
                projectile.ai[0] += 1f;

            projectile.rotation += 0.3f * projectile.direction;
        }

        public void Convert(int i, int j, int size = 4)
        {
            for (int k = i - size; k <= i + size; k++)
            {
                for (int l = j - size; l <= j + size; l++)
                {
                    if (WorldGen.InWorld(k, l, 1) && Math.Abs(k - i) + Math.Abs(l - j) < Math.Sqrt(size * size + size * size))
                    {
                        int type = Main.tile[k, l].type;
                        int wall = Main.tile[k, l].wall;

                        // Check walls
                        if (WallID.Sets.Conversion.Stone[wall])
                        {
                            Main.tile[k, l].wall = (ushort)ModContent.WallType<Walls.ChunkstoneWall>();
                            WorldGen.SquareWallFrame(k, l, true);
                            NetMessage.SendTileSquare(-1, k, l, 1);
                        }
                        else if (WallID.Sets.Conversion.Grass[wall])
                        {
                            Main.tile[k, l].wall = (ushort)ModContent.WallType<Walls.ContagionGrassWall>();
                            WorldGen.SquareWallFrame(k, l, true);
                            NetMessage.SendTileSquare(-1, k, l, 1);
                        }

                        // Check tiles
                        if (TileID.Sets.Conversion.Stone[type])
                        {
                            Main.tile[k, l].type = (ushort)ModContent.TileType<Tiles.Chunkstone>();
                            WorldGen.SquareTileFrame(k, l, true);
                            NetMessage.SendTileSquare(-1, k, l, 1);
                        }
                        else if (TileID.Sets.Conversion.Grass[type])
                        {
                            Main.tile[k, l].type = (ushort)ModContent.TileType<Tiles.Ickgrass>();
                            WorldGen.SquareTileFrame(k, l, true);
                            NetMessage.SendTileSquare(-1, k, l, 1);
                        }
                        else if (TileID.Sets.Conversion.Ice[type])
                        {
                            Main.tile[k, l].type = (ushort)ModContent.TileType<Tiles.YellowIce>();
                            WorldGen.SquareTileFrame(k, l, true);
                            NetMessage.SendTileSquare(-1, k, l, 1);
                        }
                        else if (TileID.Sets.Conversion.Sand[type])
                        {
                            Main.tile[k, l].type = (ushort)ModContent.TileType<Tiles.Snotsand>();
                            WorldGen.SquareTileFrame(k, l, true);
                            NetMessage.SendTileSquare(-1, k, l, 1);
                        }
                        else if (TileID.Sets.Conversion.Sandstone[type])
                        {
                            Main.tile[k, l].type = (ushort)ModContent.TileType<Tiles.Snotsandstone>();
                            WorldGen.SquareTileFrame(k, l, true);
                            NetMessage.SendTileSquare(-1, k, l, 1);
                        }
                        else if (TileID.Sets.Conversion.HardenedSand[type])
                        {
                            Main.tile[k, l].type = (ushort)ModContent.TileType<Tiles.HardenedSnotsand>();
                            WorldGen.SquareTileFrame(k, l, true);
                            NetMessage.SendTileSquare(-1, k, l, 1);
                        }
                    }
                }
            }
        }
    }
}
