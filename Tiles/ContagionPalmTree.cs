using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Tiles
{
    class ContagionPalmTree : ModPalmTree
    {
        private Mod mod
        {
            get
            {
                return ModLoader.GetMod("ExxoAvalonOrigins");
            }
        }
        public override int DropWood()
        {
            return mod.ItemType("Coughwood");
        }

        public override Texture2D GetTexture()
        {
            return mod.GetTexture("Tiles/ContagionPalmTree");
        }

        public override int CreateDust()
        {
            return 184;
        }
        public override Texture2D GetTopTextures()
        {
            return mod.GetTexture("Tiles/ContagionPalmTreeTop");
        }
        //public override Texture2D GetTopTextures(int i, int j, ref int frame, ref int frameWidth, ref int frameHeight, ref int xOffsetLeft, ref int yOffset)
        //{
        //    frameWidth = 80;
        //    frameHeight = 80;
        //    yOffset += 2;
        //    //xOffsetLeft += 16;
        //    return mod.GetTexture("Tiles/ContagionPalmTreeTop");
        //}
    }
}
