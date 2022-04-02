using ExxoAvalonOrigins.Items.Placeable.Crafting;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace ExxoAvalonOrigins.Tiles;

public class CoughwoodWorkbench : ModTile
{
    public override void SetStaticDefaults()
    {
        Main.tileSolidTop[Type] = true;
        Main.tileFrameImportant[Type] = true;
        Main.tileNoAttach[Type] = true;
        Main.tileTable[Type] = true;
        Main.tileLavaDeath[Type] = true;
        TileObjectData.newTile.CopyFrom(TileObjectData.Style2x1);
        TileObjectData.newTile.CoordinateHeights = new int[] { 18 };
        TileObjectData.addTile(Type);
        AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable);
        var name = CreateMapEntryName();
        name.SetDefault("Coughwood Work Bench");
        AddMapEntry(new Color(191, 142, 111), name);
        disableSmartCursor = true;
        adjTiles = new int[] { TileID.WorkBenches };
        dustType = ModContent.DustType<Dusts.ContagionDust>();
    }

    public override void KillMultiTile(int i, int j, int frameX, int frameY)
    {
        Item.NewItem(i * 16, j * 16, 32, 16, ModContent.ItemType<CoughwoodWorkBench>());
    }
}