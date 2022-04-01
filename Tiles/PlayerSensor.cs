using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace ExxoAvalonOrigins.Tiles
{
    public class PlayerSensor : ModTile
    {
        public override void SetStaticDefaults()
        {
            AddMapEntry(Color.LightSteelBlue);
            TileID.Sets.FramesOnKillWall[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3Wall);
            TileObjectData.newTile.Width = 1;
            TileObjectData.newTile.Height = 1; TileObjectData.newTile.CoordinateHeights = new int[] { 16 };
            TileObjectData.newTile.AnchorWall = true;
            TileObjectData.addTile(Type);
            Main.tileSolid[Type] = false;
            Main.tileBlockLight[Type] = false;
            Main.tileFrameImportant[Type] = true;
            drop = ModContent.ItemType<Items.Placeable.Tile.PlayerSensor>();
            dustType = DustID.Stone;
        }
    }
}
