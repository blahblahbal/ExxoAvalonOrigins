using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.ObjectData;
using Terraria.DataStructures;

namespace ExxoAvalonOrigins.Tiles
{
	public class FallenStarTile : ModTile
	{
		public override void SetDefaults()
		{
			AddMapEntry(Color.LightYellow);
			Main.tileSolid[Type] = true;
			Main.tileBlockLight[Type] = true;
			Main.tileFrameImportant[Type] = true;
            TileID.Sets.Platforms[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
            TileObjectData.newTile.UsesCustomCanPlace = false;
            TileObjectData.newTile.LavaDeath = false;
            TileObjectData.addTile(Type);
            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsDoor);
            disableSmartCursor = true;
            drop = ModContent.ItemType<Items.Placeable.Tile.FallenStarBlock>();
            dustType = DustID.TopazBolt;
		}
	}
}
