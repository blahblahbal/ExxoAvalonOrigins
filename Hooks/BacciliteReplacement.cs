using Terraria.ModLoader;
using Terraria.ID;

namespace ExxoAvalonOrigins.Hooks
{
    class BacciliteReplacement
    {
        public static void OnTileRunner(On.Terraria.WorldGen.orig_TileRunner orig, int i, int j, double strength, int steps, int type, bool addtile, float speedx, float speedy, bool noychange, bool @override)
        {
            if (ExxoAvalonOriginsWorld.contaigon && type == TileID.Demonite)
            {
                type = ModContent.TileType<Tiles.BacciliteOre>();
            }

            orig(i, j, strength, steps, type, addtile, speedx, speedy, noychange, @override);
        }
    }
}
