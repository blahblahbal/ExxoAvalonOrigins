using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace ExxoAvalonOrigins.Tiles
{
	public class BookSwitch : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = true;
			Main.tileTable[Type] = true;
			Main.tileLavaDeath[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.StyleOnTable1x1);
			TileObjectData.addTile(Type);
			var name = CreateMapEntryName();
			name.SetDefault("Book");
			AddMapEntry(new Color(170, 48, 114), name);
            dustType = DustID.Dirt;
            drop = ModContent.ItemType<Items.Placeable.Tile.BookSwitch>();
        }
        public override bool NewRightClick(int i, int j)
        {
            Wiring.TripWire(i, j, 1, 1);
            return true;
        }
    }
}
