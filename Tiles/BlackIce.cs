using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Tiles;

public class BlackIce : ModTile
{
    public override void SetStaticDefaults()
    {
        AddMapEntry(new Color(127, 104, 135));
        Main.tileSolid[Type] = true;
        Main.tileBlockLight[Type] = true;
        drop = Mod.Find<ModItem>("BlackIceBlock").Type;
        Main.tileMerge[Type][TileID.IceBlock] = true;
        Main.tileMerge[TileID.IceBlock][Type] = true;
        Main.tileShine2[Type] = true;
        dustType = DustID.Clentaminator_Purple;
        soundType = SoundID.Item;
        soundStyle = 50;
    }

    public override void KillTile(int i, int j, ref bool fail, ref bool effectOnly, ref bool noItem)
    {
        if (!fail)
        {
            ExxoAvalonOriginsWorld.WorldDarkMatterTiles--;
        }
        base.KillTile(i, j, ref fail, ref effectOnly, ref noItem);
    }
}