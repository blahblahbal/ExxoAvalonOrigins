using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Generation;
using Terraria.ModLoader;
using Terraria.World.Generation;

namespace ExxoAvalonOrigins.World.Passes
{
    class JungleWallVariety
    {
		public static void Method(GenerationProgress progress)
		{
			progress.Message = Lang.gen[79].Value;
			float num348 = (float)(Main.maxTilesX * Main.maxTilesY) / 5040000f;
			int num349 = (int)(300f * num348);
			int num350 = num349;
			ShapeData shapeData = new ShapeData();
			bool foundInvalidTile = false;
			while (num349 > 0)
			{
				progress.Set(1f - (float)num349 / (float)num350);
				Point point = WorldGen.RandomWorldPoint((int)WorldGen.worldSurface, 2, 190, 2);
				Tile tile4 = Main.tile[point.X, point.Y];
				Tile tile5 = Main.tile[point.X, point.Y - 1];
				int b = 0;
				if (tile4.type == ModContent.TileType<Tiles.TropicalMud>() || tile4.type == ModContent.TileType<Tiles.TropicalGrass>())
				{
					b = ModContent.WallType<Walls.TropicalGrassWall>();
					//b = (byte)(204 + WorldGen.genRand.Next(4));
				}
				else if (tile4.type == 1 && tile5.wall == 0)
				{
					b = (((double)point.Y < WorldGen.rockLayer) ? ((196 + WorldGen.genRand.Next(4))) : ((point.Y >= WorldGen.lavaLine) ? ((208 + WorldGen.genRand.Next(4))) : ((212 + WorldGen.genRand.Next(4)))));
				}
				if (tile4.active() && b != 0 && !tile5.active())
				{
					foundInvalidTile = false;
					bool flag26 = WorldUtils.Gen(new Point(point.X, point.Y - 1), new ShapeFloodFill(1000), Actions.Chain(new Modifiers.IsNotSolid(), new Actions.Blank().Output(shapeData), new Actions.ContinueWrapper(Actions.Chain(new Modifiers.IsTouching(true, (ushort)ModContent.TileType<Tiles.TropicalGrass>(), 147, 161, 396, 397), new Actions.Custom(delegate
					{
						foundInvalidTile = true;
						return true;
					})))));
					if (shapeData.Count > 50 && flag26 && !foundInvalidTile)
					{
						WorldUtils.Gen(new Point(point.X, point.Y), new ModShapes.OuterOutline(shapeData, useDiagonals: true, useInterior: true), new PlaceWall(b));
						num349--;
					}
					shapeData.Clear();
				}
			}
		}
    }
	public class PlaceWall : GenAction
	{
		private int _type;

		private bool _neighbors;

		public PlaceWall(int type, bool neighbors = true)
		{
			this._type = type;
			this._neighbors = neighbors;
		}

		public override bool Apply(Point origin, int x, int y, params object[] args)
		{
			GenBase._tiles[x, y].wall = (ushort)this._type;
			WorldGen.SquareWallFrame(x, y);
			if (this._neighbors)
			{
				WorldGen.SquareWallFrame(x + 1, y);
				WorldGen.SquareWallFrame(x - 1, y);
				WorldGen.SquareWallFrame(x, y - 1);
				WorldGen.SquareWallFrame(x, y + 1);
			}
			return base.UnitApply(origin, x, y, args);
		}
	}
}
