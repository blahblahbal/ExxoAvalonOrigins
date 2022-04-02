using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Tiles;

class TropicalTree : ModTree
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
        return Mod.Find<ModItem>("TropicalWood").Type;
    }

    public override Texture2D GetTexture()
    {
        return mod.Assets.Request<Texture2D>("Tiles/TropicalTree").Value;
    }

    public override Texture2D GetBranchTextures(int i, int j, int trunkOffset, ref int frame)
    {
        return mod.Assets.Request<Texture2D>("Tiles/TropicalTreeBranches").Value;
    }
    public override int CreateDust()
    {
        return 51;
    }
    public override Texture2D GetTopTextures(int i, int j, ref int frame, ref int frameWidth, ref int frameHeight, ref int xOffsetLeft, ref int yOffset)
    {
        frameWidth = 116;
        frameHeight = 96;
        //yOffset += 2;
        xOffsetLeft += 18;
        return mod.Assets.Request<Texture2D>("Tiles/TropicalTreeTop").Value;
    }
}