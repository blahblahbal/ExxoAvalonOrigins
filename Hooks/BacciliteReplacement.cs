using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria.ID;

namespace ExxoAvalonOrigins.Hooks
{
    class BacciliteReplacement
    {
        public static void OnTileRunner(On.Terraria.WorldGen.orig_TileRunner orig, int i, int j, double strength, int steps, int type, bool addtile, float speedx, float speedy, bool noychange, bool @override)
        {
            int newTile = type;
            if (ExxoAvalonOriginsWorld.generatingBaccilite && type == TileID.Demonite)
            {
                newTile = ModContent.TileType<Tiles.BacciliteOre>();
                ExxoAvalonOriginsWorld.generatingBaccilite = false;
            }

            orig(i, j, strength, steps, newTile, addtile, speedx, speedy, noychange, @override);
        }
    }
}
