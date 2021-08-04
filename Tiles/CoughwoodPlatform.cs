using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace ExxoAvalonOrigins.Tiles
{
    public class CoughwoodPlatform : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileLighted[Type] = true;
            Main.tileFrameImportant[Type] = true;
            Main.tileSolidTop[Type] = true;
            Main.tileSolid[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileTable[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileID.Sets.Platforms[Type] = true;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16 };
            TileObjectData.newTile.CoordinateWidth = 16;
            TileObjectData.newTile.CoordinatePadding = 2;
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.StyleMultiplier = 27;
            TileObjectData.newTile.StyleWrapLimit = 27;
            TileObjectData.newTile.UsesCustomCanPlace = false;
            TileObjectData.newTile.LavaDeath = true;
            TileObjectData.addTile(Type);
            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsDoor);
            AddMapEntry(new Color(200, 200, 200));
            drop = ModContent.ItemType<Items.CoughwoodPlatform>();
            disableSmartCursor = true;
            adjTiles = new int[] { TileID.Platforms };
            dustType = 184;
        }

        public override void PostSetDefaults()
        {
            Main.tileNoSunLight[Type] = false;
        }
    }
}