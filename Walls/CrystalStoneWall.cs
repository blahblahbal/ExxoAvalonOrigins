using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework.Graphics;

namespace ExxoAvalonOrigins.Walls;

public class CrystalStoneWall : ModWall
{
    public override void SetStaticDefaults()
    {
        AddMapEntry(new Color(86, 51, 76));
        dustType = DustID.PinkCrystalShard;
    }
    //public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
    //{
    //    //spriteBatch.Draw();
    //}
}