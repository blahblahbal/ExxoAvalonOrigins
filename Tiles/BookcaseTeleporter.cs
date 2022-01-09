﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace ExxoAvalonOrigins.Tiles
{
	public class BookcaseTeleporter : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileSolidTop[Type] = true;
			Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = true;
			Main.tileTable[Type] = true;
			Main.tileLavaDeath[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x4);
			TileObjectData.newTile.CoordinateHeights = new[]{ 16, 16, 16, 16 };
			TileObjectData.addTile(Type);
			AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable);
			var name = CreateMapEntryName();
			name.SetDefault("Bookcase");
			AddMapEntry(new Color(191, 142, 111), name);
            dustType = DustID.Dirt;
        }

		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(i * 16, j * 16, 32, 16, ModContent.ItemType<Items.Placeable.Furniture.BookcaseTeleporter>());
		}
        public override bool NewRightClick(int i, int j)
        {
            if (Main.tile[i, j].frameX == 18 && Main.tile[i, j].frameY == 36)
            {
                Wiring.TripWire(i, j, 1, 1);
                return true;
            }
            return false;
        }
        public override void HitWire(int i, int j)
        {
            ExxoAvalonOriginsWorld.specialWireHitCount++;
            if (ExxoAvalonOriginsWorld.specialWireHitCount == 2)
            {
                Player player = Main.LocalPlayer;
                Wiring.SkipWire(i, j);
                Point tileC = player.position.ToTileCoordinates();
                if ((Main.tile[tileC.X, tileC.Y].active() && Main.tile[tileC.X, tileC.Y].type == Type) ||
                    (Main.tile[tileC.X + 1, tileC.Y].active() && Main.tile[tileC.X + 1, tileC.Y].type == Type) ||
                    (Main.tile[tileC.X, tileC.Y + 1].active() && Main.tile[tileC.X, tileC.Y + 1].type == Type) ||
                    (Main.tile[tileC.X + 1, tileC.Y + 1].active() && Main.tile[tileC.X + 1, tileC.Y + 1].type == Type) ||
                    (Main.tile[tileC.X, tileC.Y + 2].active() && Main.tile[tileC.X, tileC.Y + 2].type == Type) ||
                    (Main.tile[tileC.X + 1, tileC.Y + 2].active() && Main.tile[tileC.X + 1, tileC.Y + 2].type == Type) ||
                    (Main.tile[tileC.X, tileC.Y + 3].active() && Main.tile[tileC.X, tileC.Y + 3].type == Type) ||
                    (Main.tile[tileC.X + 1, tileC.Y + 3].active() && Main.tile[tileC.X + 1, tileC.Y + 3].type == Type))
                {
                    if (!Main.tile[i, j + 1].active())
                    {
                        player.Teleport(new Vector2(i * 16, j * 16 - 16));
                    }
                    if (!Main.tile[i, j + 1].active() || !Main.tile[i, j + 2].active())
                    {
                        player.Teleport(new Vector2(i * 16, j * 16));
                    }
                    else
                    {
                        player.Teleport(new Vector2(i * 16, j * 16 - 32));
                    }
                }
                ExxoAvalonOriginsWorld.specialWireHitCount = 0;
            }
        }
    }
}
