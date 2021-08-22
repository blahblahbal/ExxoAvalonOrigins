using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.World.Generation;

namespace ExxoAvalonOrigins.World.Passes
{
    class Setup
    {
        public static void Method(GenerationProgress progress)
        {
            progress.Message = "Setting up Avalonian World Gen";

            if (ExxoAvalonOriginsWorld.osmiumOre == ExxoAvalonOriginsWorld.OsmiumVariant.random)
            {
                ExxoAvalonOriginsWorld.osmiumOre = (ExxoAvalonOriginsWorld.OsmiumVariant)WorldGen.genRand.Next(3);
            }

            int phmOreTier1 = WorldGen.genRand.Next(3);
            int phmOreTier2 = WorldGen.genRand.Next(3);
            int phmOreTier3 = WorldGen.genRand.Next(3);
            int phmOreTier4 = WorldGen.genRand.Next(3);

            // Set altenative prehard ores
            if (phmOreTier1 == 0)
            {
                WorldGen.CopperTierOre = (ushort)ModContent.TileType<Tiles.BronzeOre>();
                WorldGen.copperBar = ModContent.ItemType<Items.BronzeBar>();
            }
            if (phmOreTier2 == 0)
            {
                WorldGen.IronTierOre = (ushort)ModContent.TileType<Tiles.NickelOre>();
                WorldGen.ironBar = ModContent.ItemType<Items.NickelBar>();
            }
            if (phmOreTier3 == 0)
            {
                WorldGen.SilverTierOre = (ushort)ModContent.TileType<Tiles.ZincOre>();
                WorldGen.silverBar = ModContent.ItemType<Items.ZincBar>();
            }
            if (phmOreTier4 == 0)
            {
                WorldGen.GoldTierOre = (ushort)ModContent.TileType<Tiles.BismuthOre>();
                WorldGen.goldBar = ModContent.ItemType<Items.BismuthBar>();
            }
            ExxoAvalonOriginsWorld.phmOreTier1 = WorldGen.CopperTierOre;
            ExxoAvalonOriginsWorld.phmOreTier2 = WorldGen.IronTierOre;
            ExxoAvalonOriginsWorld.phmOreTier3 = WorldGen.SilverTierOre;
            ExxoAvalonOriginsWorld.phmOreTier4 = WorldGen.GoldTierOre;
        }
    }
}
