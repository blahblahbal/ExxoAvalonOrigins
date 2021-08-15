using Terraria;
using Terraria.IO;
using Terraria.ModLoader;
using Terraria.World.Generation;
using System.Reflection;

namespace ExxoAvalonOrigins.World.Passes
{
    class ResetOverride
    {
        public static void Method(GenerationProgress progress)
        {
			Liquid.ReInit();
			WorldGen.noTileActions = true;
			progress.Message = "";
			WorldGen.SetupStatueList();
			WorldGen.RandomizeWeather();
			Main.cloudAlpha = 0f;
			Main.maxRaining = 0f;
			WorldFile.tempMaxRain = 0f;
			Main.raining = false;
			FieldInfo heartCount = typeof(WorldGen).GetField("heartCount", BindingFlags.NonPublic | BindingFlags.Static);
			heartCount.SetValue(null, 0);
			//WorldGen.heartCount = 0;
			Main.checkXMas();
			Main.checkHalloween();
			WorldGen.gen = true;
			MethodInfo resetGenerator = typeof(WorldGen).GetMethod("ResetGenerator", BindingFlags.NonPublic | BindingFlags.Static);
			resetGenerator.Invoke(null, null);
			// heartCount.SetValue(null, 0);
			//WorldGen.ResetGenerator();
			WorldGen.numLarva = 0;
			int num706 = 86400;
			Main.slimeRainTime = -WorldGen.genRand.Next(num706 * 2, num706 * 3);
			Main.cloudBGActive = -WorldGen.genRand.Next(8640, 86400);
			WorldGen.CopperTierOre = 7;
			WorldGen.IronTierOre = 6;
			WorldGen.SilverTierOre = 9;
			WorldGen.GoldTierOre = 8;
			WorldGen.copperBar = 20;
			WorldGen.ironBar = 22;
			WorldGen.silverBar = 21;
			WorldGen.goldBar = 19;
			// Overridden in Shinies
			//if (WorldGen.genRand.Next(2) == 0)
			//{
			//	copper = 166;
			//	WorldGen.copperBar = 703;
			//	WorldGen.CopperTierOre = 166;
			//}
			//if (WorldGen.genRand.Next(2) == 0)
			//{
			//	iron = 167;
			//	WorldGen.ironBar = 704;
			//	WorldGen.IronTierOre = 167;
			//}
			//if (WorldGen.genRand.Next(2) == 0)
			//{
			//	silver = 168;
			//	WorldGen.silverBar = 705;
			//	WorldGen.SilverTierOre = 168;
			//}
			//if (WorldGen.genRand.Next(2) == 0)
			//{
			//	gold = 169;
			//	WorldGen.goldBar = 706;
			//	WorldGen.GoldTierOre = 169;
			//}
			Main.worldID = WorldGen.genRand.Next(int.MaxValue);
			WorldGen.RandomizeTreeStyle();
			WorldGen.RandomizeCaveBackgrounds();
			WorldGen.RandomizeBackgrounds();
			WorldGen.RandomizeMoonState();
		}
    }
}
