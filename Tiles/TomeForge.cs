using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace ExxoAvalonOrigins.Tiles;

public class TomeForge : ModTile
{
    public override void SetStaticDefaults()
    {
        var name = CreateMapEntryName();
        name.SetDefault("Tome Forge");
        AddMapEntry(Color.OrangeRed);
        TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
        TileObjectData.newTile.CoordinateHeights = new[]
        {
            16,
            18,
            18
        };
        TileObjectData.newTile.DrawYOffset = 2;
        TileObjectData.newTile.StyleHorizontal = true;
        TileObjectData.newTile.LavaDeath = false;
        TileObjectData.addTile(Type);
        Main.tileLighted[Type] = true;
        Main.tileFrameImportant[Type] = true;
    }

    public override void KillMultiTile(int i, int j, int frameX, int frameY)
    {
        Item.NewItem(i * 16, j * 16, 48, 32, ModContent.ItemType<Items.Placeable.Crafting.TomeForge>());
    }
}