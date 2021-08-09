using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Hooks
{
    class JungleCoords
    {
        public static void OnJungleRunner(On.Terraria.WorldGen.orig_JungleRunner orig, int i, int j)
        {
            ExxoAvalonOriginsWorld.jungleX = i;
            ExxoAvalonOriginsWorld.jungleLocationKnown = true;
            orig(i, j);
        }
    }
}
