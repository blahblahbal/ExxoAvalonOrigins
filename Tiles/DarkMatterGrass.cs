using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Tiles;

public class DarkMatterGrass : ModTile
{
    public override void SetStaticDefaults()
    {
        AddMapEntry(new Color(120, 15, 170));
        Main.tileSolid[Type] = true;
        Main.tileBrick[Type] = true;
        Main.tileBlockLight[Type] = true;
        Main.tileBlendAll[Type] = true;
        drop = Mod.Find<ModItem>("DarkMatterGrass").Type;
        dustType = ModContent.DustType<Dusts.DarkMatterDust>();
    }

    public override int SaplingGrowthType(ref int style)
    {
        style = 0;
        return ModContent.TileType<DarkMatterSapling>();
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