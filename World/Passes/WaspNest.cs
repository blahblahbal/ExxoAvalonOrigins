using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.World.Generation;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.ID;

namespace ExxoAvalonOrigins.World.Passes
{
    class WaspNest
    {
        public static void Method(GenerationProgress progress)
        {
            Structures.Nest.CreateWaspNest(Main.maxTilesX / 2, 200);
        }
    }
}
