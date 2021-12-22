using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace ExxoAvalonOrigins.Tiles
{
	public class ResistantWoodBed : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileFrameImportant[Type] = true;
			Main.tileLavaDeath[Type] = false;
			TileID.Sets.HasOutlines[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style4x2);
			TileObjectData.newTile.CoordinateHeights = new int[]{ 16, 18 };
            TileObjectData.newTile.LavaDeath = false;
            TileObjectData.addTile(Type);
			var name = CreateMapEntryName();
			name.SetDefault("Resistant Wood Bed");
			AddMapEntry(new Color(191, 142, 111), name);
			disableSmartCursor = true;
			adjTiles = new int[]{ TileID.Beds };
			bed = true;
            dustType = DustID.Wraith;
        }

		public override bool HasSmartInteract()
		{
			return true;
		}

		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(i * 16, j * 16, 64, 32, ModContent.ItemType<Items.Placeable.Furniture.ResistantWoodBed>());
		}

		public override void RightClick(int i, int j)
		{
			var player = Main.LocalPlayer;
			var tile = Main.tile[i, j];
			var spawnX = i - tile.frameX / 18;
			var spawnY = j + 2;
			spawnX += tile.frameX >= 72 ? 5 : 2;
			if (tile.frameY % 38 != 0)
			{
				spawnY--;
			}
			player.FindSpawn();
			if (player.SpawnX == spawnX && player.SpawnY == spawnY)
			{
				player.RemoveSpawn();
				Main.NewText("Spawn point removed!", 255, 240, 20, false);
			}
			else if (Player.CheckSpawn(spawnX, spawnY))
			{
				player.ChangeSpawn(spawnX, spawnY);
				Main.NewText("Spawn point set!", 255, 240, 20, false);
			}
		}

		public override void MouseOver(int i, int j)
		{
			var player = Main.LocalPlayer;
			player.noThrow = 2;
			player.showItemIcon = true;
			player.showItemIcon2 = ModContent.ItemType<Items.Placeable.Furniture.ResistantWoodBed>();
		}
	}
}
