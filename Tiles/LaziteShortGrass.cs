using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Tiles
{
    public class LaziteShortGrass : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileCut[Type] = true;
            Main.tileSolid[Type] = false;
            Main.tileNoAttach[Type] = true;
            Main.tileNoFail[Type] = true;
            Main.tileLavaDeath[Type] = true;
            Main.tileWaterDeath[Type] = true;
            Main.tileFrameImportant[Type] = true;
            dustType = DustID.SapphireBolt;
            soundStyle = 1;
            soundType = SoundID.Grass;
            AddMapEntry(new Color(10, 40, 175));
        }

        public override void SetDrawPositions(int i, int j, ref int width, ref int offsetY, ref int height)
        {
            offsetY = 2;
        }
    }
}
