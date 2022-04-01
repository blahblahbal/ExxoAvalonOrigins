using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Tiles
{
    class ContagionTree : ModTree
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
            return Mod.Find<ModItem>("Coughwood").Type;
        }

        public override Texture2D GetTexture()
        {
            return mod.Assets.Request<Texture2D>("Tiles/ContagionTree").Value;
        }

        public override Texture2D GetBranchTextures(int i, int j, int trunkOffset, ref int frame)
        {
            return mod.Assets.Request<Texture2D>("Tiles/ContagionTreeBranches").Value;
        }
        public override int CreateDust()
        {
            return ModContent.DustType<Dusts.CoughwoodDust>();
        }
        public override Texture2D GetTopTextures(int i, int j, ref int frame, ref int frameWidth, ref int frameHeight, ref int xOffsetLeft, ref int yOffset)
        {
            frameWidth = 80;
            frameHeight = 80;
            yOffset += 2;
            //xOffsetLeft += 16;
            return mod.Assets.Request<Texture2D>("Tiles/ContagionTreeTop").Value;
        }
    }
}
