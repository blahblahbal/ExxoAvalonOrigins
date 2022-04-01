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
            Projectile.width = 6;
            Projectile.height = 6;
            Projectile.friendly = true;
            Projectile.alpha = 255;
            Projectile.penetrate = -1;
            Projectile.extraUpdates = 2;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
        }
        public override bool? CanCutTiles()
        {
            return false;
        }
        public override void AI()
        {

            int dustType = ModContent.DustType<Dusts.YellowSolutionDust>();

            if (Projectile.owner == Main.myPlayer)
                Convert((int)(Projectile.position.X + Projectile.width / 2) / 16, (int)(Projectile.position.Y + Projectile.height / 2) / 16, 2);

            if (Projectile.timeLeft > 133)
                Projectile.timeLeft = 133;

            if (Projectile.ai[0] > 7f)
            {
                float dustScale = 1f;

                if (Projectile.ai[0] == 8f)
                    dustScale = 0.2f;
                else if (Projectile.ai[0] == 9f)
                    dustScale = 0.4f;
                else if (Projectile.ai[0] == 10f)
                    dustScale = 0.6f;
                else if (Projectile.ai[0] == 11f)
                    dustScale = 0.8f;

                Projectile.ai[0] += 1f;

                for (int i = 0; i < 1; i++)
                {
                    int dustIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, dustType, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f, 100);
                    Dust dust = Main.dust[dustIndex];
                    dust.noGravity = true;
                    dust.scale *= 1.75f;
                    dust.velocity.X *= 2f;
                    dust.velocity.Y *= 2f;
                    dust.scale *= dustScale;
                }
            }
            else
                Projectile.ai[0] += 1f;

            Projectile.rotation += 0.3f * Projectile.direction;
        }

        public void Convert(int i, int j, int size = 4)
        {
            for (int k = i - size; k <= i + size; k++)
            {
                for (int l = j - size; l <= j + size; l++)
                {
                    if (WorldGen.InWorld(k, l, 1) && Math.Abs(k - i) + Math.Abs(l - j) < Math.Sqrt(size * size + size * size))
                    {
                        int type = Main.tile[k, l].TileType;
                        int wall = Main.tile[k, l].WallType;

                        // Check walls
                        if (WallID.Sets.Conversion.Stone[wall])
                        {
                            Main.tile[k, l].WallType = (ushort)ModContent.WallType<Walls.ChunkstoneWall>();
                            WorldGen.SquareWallFrame(k, l, true);
                            NetMessage.SendTileSquare(-1, k, l, 1);
                        }
                        else if (WallID.Sets.Conversion.Grass[wall])
                        {
                            Main.tile[k, l].WallType = (ushort)ModContent.WallType<Walls.ContagionGrassWall>();
                            WorldGen.SquareWallFrame(k, l, true);
                            NetMessage.SendTileSquare(-1, k, l, 1);
                        }

                        // Check tiles
                        if (TileID.Sets.Conversion.Stone[type])
                        {
                            Main.tile[k, l].TileType = (ushort)ModContent.TileType<Tiles.Chunkstone>();
                            WorldGen.SquareTileFrame(k, l, true);
                            NetMessage.SendTileSquare(-1, k, l, 1);
                        }
                        else if (TileID.Sets.Conversion.Grass[type])
                        {
                            Main.tile[k, l].TileType = (ushort)ModContent.TileType<Tiles.Ickgrass>();
                            WorldGen.SquareTileFrame(k, l, true);
                            NetMessage.SendTileSquare(-1, k, l, 1);
                        }
                        else if (TileID.Sets.Conversion.Ice[type])
                        {
                            Main.tile[k, l].TileType = (ushort)ModContent.TileType<Tiles.YellowIce>();
                            WorldGen.SquareTileFrame(k, l, true);
                            NetMessage.SendTileSquare(-1, k, l, 1);
                        }
                        else if (TileID.Sets.Conversion.Sand[type])
                        {
                            Main.tile[k, l].TileType = (ushort)ModContent.TileType<Tiles.Snotsand>();
                            WorldGen.SquareTileFrame(k, l, true);
                            NetMessage.SendTileSquare(-1, k, l, 1);
                        }
                        else if (TileID.Sets.Conversion.Sandstone[type])
                        {
                            Main.tile[k, l].TileType = (ushort)ModContent.TileType<Tiles.Snotsandstone>();
                            WorldGen.SquareTileFrame(k, l, true);
                            NetMessage.SendTileSquare(-1, k, l, 1);
                        }
                        else if (TileID.Sets.Conversion.HardenedSand[type])
                        {
                            Main.tile[k, l].TileType = (ushort)ModContent.TileType<Tiles.HardenedSnotsand>();
                            WorldGen.SquareTileFrame(k, l, true);
                            NetMessage.SendTileSquare(-1, k, l, 1);
                        }
                    }
                }
            }
        }
    }
}
