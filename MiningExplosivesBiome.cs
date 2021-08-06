// Warning: Some assembly references could not be resolved automatically. This might lead to incorrect decompilation of some parts,
// for ex. property getter/setter access. To get optimal decompilation results, please manually add the missing references to the list of loaded assemblies.
// Terraria.GameContent.Biomes.MiningExplosivesBiome
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Generation;
using Terraria.World.Generation;

namespace ExxoAvalonOrigins
{
    public class MiningExplosivesBiome : MicroBiome
    {
        public override bool Place(Point origin, StructureMap structures)
        {
            if (WorldGen.SolidTile(origin.X, origin.Y))
            {
                return false;
            }
            ushort type = Utils.SelectRandom<ushort>(GenBase._random, (ushort)(WorldGen.GoldTierOre), (ushort)(WorldGen.SilverTierOre), (ushort)(WorldGen.IronTierOre), (ushort)(WorldGen.CopperTierOre));
            double num = GenBase._random.NextDouble() * 2.0 - 1.0;
            if (!WorldUtils.Find(origin, Searches.Chain((num > 0.0) ? ((GenSearch)new Searches.Right(40)) : ((GenSearch)new Searches.Left(40)), new Conditions.IsSolid()), out origin))
            {
                return false;
            }
            if (!WorldUtils.Find(origin, Searches.Chain(new Searches.Down(80), new Conditions.IsSolid()), out origin))
            {
                return false;
            }
            ShapeData shapeData = new ShapeData();
            Ref<int> @ref = new Ref<int>(0);
            Ref<int> ref2 = new Ref<int>(0);
            WorldUtils.Gen(origin, new ShapeRunner(10f, 20, new Vector2((float)num, 1f)).Output(shapeData), Actions.Chain(new Modifiers.Blotches(), new Actions.Scanner(@ref), new Modifiers.IsSolid(), new Actions.Scanner(ref2)));
            if (ref2.Value < @ref.Value / 2)
            {
                return false;
            }
            Rectangle area = new Rectangle(origin.X - 15, origin.Y - 10, 30, 20);
            if (!structures.CanPlace(area))
            {
                return false;
            }
            WorldUtils.Gen(origin, new ModShapes.All(shapeData), new Actions.SetTile(type, setSelfFrames: true));
            WorldUtils.Gen(new Point(origin.X - (int)(num * -5.0), origin.Y - 5), new Shapes.Circle(5), Actions.Chain(new Modifiers.Blotches(), new Actions.ClearTile(frameNeighbors: true)));
            Point result;
            int num3 = 1 & (WorldUtils.Find(new Point(origin.X - ((num > 0.0) ? 3 : (-3)), origin.Y - 3), Searches.Chain(new Searches.Down(10), new Conditions.IsSolid()), out result) ? 1 : 0);
            int num2 = ((GenBase._random.Next(4) == 0) ? 3 : 7);
            if ((num3 & (WorldUtils.Find(new Point(origin.X - ((num > 0.0) ? (-num2) : num2), origin.Y - 3), Searches.Chain(new Searches.Down(10), new Conditions.IsSolid()), out var result2) ? 1 : 0)) == 0)
            {
                return false;
            }
            result.Y--;
            result2.Y--;
            Tile tile3 = GenBase._tiles[result.X, result.Y + 1];
            tile3.slope(0);
            tile3.halfBrick(halfBrick: false);
            for (int i = -1; i <= 1; i++)
            {
                WorldUtils.ClearTile(result2.X + i, result2.Y);
                Tile tile2 = GenBase._tiles[result2.X + i, result2.Y + 1];
                if (!WorldGen.SolidOrSlopedTile(tile2))
                {
                    tile2.ResetToType(1);
                    tile2.active(active: true);
                }
                tile2.slope(0);
                tile2.halfBrick(halfBrick: false);
                WorldUtils.TileFrame(result2.X + i, result2.Y + 1, frameNeighbors: true);
            }
            WorldGen.PlaceTile(result.X, result.Y, 141);
            WorldGen.PlaceTile(result2.X, result2.Y, 411, mute: true, forced: true);
            WorldUtils.WireLine(result, result2);
            structures.AddStructure(area, 5);
            return true;
        }
    }
}
