using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Tiles;

class ResistantTree : ModTree
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
        return Mod.Find<ModItem>("ResistantWood").Type;
    }

    public override Texture2D GetTexture()
    {
        return mod.Assets.Request<Texture2D>("Tiles/ResistantTree").Value;
    }

    public override Texture2D GetBranchTextures(int i, int j, int trunkOffset, ref int frame)
    {
        return mod.Assets.Request<Texture2D>("Tiles/ResistantTreeBranches").Value;
    }
    public override int CreateDust()
    {
        return 54;
    }
    public override Texture2D GetTopTextures(int i, int j, ref int frame, ref int frameWidth, ref int frameHeight, ref int xOffsetLeft, ref int yOffset)
    {
        frameWidth = 80;
        frameHeight = 80;
        yOffset += 2;
        //xOffsetLeft += 16;
        return mod.Assets.Request<Texture2D>("Tiles/ResistantTreeTop").Value;
    }
}