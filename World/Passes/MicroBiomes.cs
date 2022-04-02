using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Biomes;
using Terraria.GameContent.Generation;
using Terraria.WorldBuilding;

namespace ExxoAvalonOrigins.World.Passes;

class MicroBiomes
{
    public static void Method(GenerationProgress progress)
    {
        progress.Message = Lang.gen[76].Value + "..Thin Ice";
        float num = (float)(Main.maxTilesX * Main.maxTilesY) / 5040000f;
        float num2 = (float)Main.maxTilesX / 4200f;
        int num3 = (int)((float)WorldGen.genRand.Next(3, 6) * num);
        int num4 = 0;
        while (num4 < num3)
        {
            if (Biomes<ThinIceBiome>.Place(WorldGen.RandomWorldPoint((int)Main.worldSurface + 20, 50, 200, 50), WorldGen.structures))
            {
                num4++;
            }
        }
        progress.Set(0.1f);
        progress.Message = Lang.gen[76]?.ToString() + "..Enchanted Swords";
        int num5 = (int)Math.Ceiling(num);
        int num6 = 0;
        Point origin = default(Point);
        while (num6 < num5)
        {
            origin.Y = (int)WorldGen.worldSurface + WorldGen.genRand.Next(50, 100);
            if (WorldGen.genRand.Next(2) == 0)
            {
                origin.X = WorldGen.genRand.Next(50, (int)((float)Main.maxTilesX * 0.3f));
            }
            else
            {
                origin.X = WorldGen.genRand.Next((int)((float)Main.maxTilesX * 0.7f), Main.maxTilesX - 50);
            }
            if (Biomes<Terraria.GameContent.Biomes.EnchantedSwordBiome>.Place(origin, WorldGen.structures))
            {
                num6++;
            }
        }
        progress.Set(0.2f);
        progress.Message = Lang.gen[76]?.ToString() + "..Campsites";
        int num7 = (int)((float)WorldGen.genRand.Next(6, 12) * num);
        int num8 = 0;
        while (num8 < num7)
        {
            if (Biomes<CampsiteBiome>.Place(WorldGen.RandomWorldPoint((int)Main.worldSurface, 50, 200, 50), WorldGen.structures))
            {
                num8++;
            }
        }
        progress.Message = Lang.gen[76]?.ToString() + "..Mining Explosives";
        progress.Set(0.25f);
        int num9 = (int)((float)WorldGen.genRand.Next(14, 30) * num);
        int num10 = 0;
        while (num10 < num9)
        {
            if (Biomes<MiningExplosivesBiome>.Place(WorldGen.RandomWorldPoint((int)WorldGen.rockLayer, 50, 200, 50), WorldGen.structures))
            {
                num10++;
            }
        }
        progress.Message = Lang.gen[76]?.ToString() + "..Mahogany Trees";
        progress.Set(0.3f);
        int num11 = (int)((float)WorldGen.genRand.Next(6, 12) * num2);
        int num12 = 0;
        int num13 = 0;
        while (num12 < num11 && num13 < 20000)
        {
            if (Biomes<MahoganyTreeBiome>.Place(WorldGen.RandomWorldPoint((int)Main.worldSurface + 50, 50, 500, 50), WorldGen.structures))
            {
                num12++;
            }
            num13++;
        }
        progress.Message = Lang.gen[76]?.ToString() + "..Corruption Pits";
        progress.Set(0.4f);
        if (!WorldGen.crimson && !ExxoAvalonOriginsWorld.contagion)
        {
            int num14 = (int)((float)WorldGen.genRand.Next(1, 3) * num);
            int num15 = 0;
            while (num15 < num14)
            {
                if (Biomes<CorruptionPitBiome>.Place(WorldGen.RandomWorldPoint((int)Main.worldSurface, 50, 500, 50), WorldGen.structures))
                {
                    num15++;
                }
            }
        }
        progress.Message = Lang.gen[76]?.ToString() + "..Minecart Tracks";
        progress.Set(0.5f);
        TrackGenerator.Run((int)(10f * num), (int)(num * 25f) + 250);
        progress.Set(1f);
    }
}