using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.ObjectData;

namespace ExxoAvalonOrigins.Tiles
{
	public class BiomeBombs : ModTile
	{
		public override void SetDefaults()
		{
			AddMapEntry(Color.Gray);
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
			TileObjectData.addTile(Type);
			Main.tileFrameImportant[Type] = true;
		}

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            int item = 0;
            switch (frameX % 54)
            {
                case 0:
                    item = ModContent.ItemType<Items.Placeable.Tile.PurityBomb>();
                    break;
                case 1:
                    item = ModContent.ItemType<Items.Placeable.Tile.CorruptionBomb>();
                    break;
                case 2:
                    item = ModContent.ItemType<Items.Placeable.Tile.JungleBomb>();
                    break;
                case 3:
                    item = ModContent.ItemType<Items.Placeable.Tile.CrimsonBomb>();
                    break;
                case 4:
                    item = ModContent.ItemType<Items.Placeable.Tile.ContagionBomb>();
                    break;
                case 5:
                    item = ModContent.ItemType<Items.Placeable.Tile.MushroomBomb>();
                    break;
                case 6:
                    item = ModContent.ItemType<Items.Placeable.Tile.HallowBomb>();
                    break;
                case 7:
                    item = ModContent.ItemType<Items.Placeable.Tile.TropicsBomb>();
                    break;
            }
            if (item > 0)
            {
                Item.NewItem(i * 16, j * 16, 48, 48, item);
            }
        }

        public override bool NewRightClick(int i, int j)
        {
            int typeC = 2;
            Tile tile = Main.tile[i, j];
            if (tile.frameX <= 52) typeC = 0;
            else if (tile.frameX >= 54 && tile.frameX <= 106) typeC = 1;
            else if (tile.frameX >= 108 && tile.frameX <= 160) typeC = 5;
            else if (tile.frameX >= 162 && tile.frameX <= 214) typeC = 4;
            else if (tile.frameX >= 216 && tile.frameX <= 268) typeC = 6;
            else if (tile.frameX >= 270 && tile.frameX <= 322) typeC = 3;
            else if (tile.frameX >= 324 && tile.frameX <= 376) typeC = 2;
            else if (tile.frameX >= 378 && tile.frameX <= 430) typeC = 7;
            ExxoAvalonOriginsWorld.BCBConvert(i, j, typeC, 75);
            WorldGen.KillTile(i, j, noItem: true);
            if (!Main.tile[i, j].active() && Main.netMode != NetmodeID.SinglePlayer)
            {
                NetMessage.SendData(MessageID.TileChange, -1, -1, null, 0, i, j);
            }
            return true;
        }
        public override void MouseOver(int i, int j)
        {
            Player player = Main.LocalPlayer;
            player.noThrow = 2;
            player.showItemIcon = true;
            int item = 0;
            switch (Main.tile[i, j].frameX % 54)
            {
                case 0:
                    item = ModContent.ItemType<Items.Placeable.Tile.PurityBomb>();
                    break;
                case 1:
                    item = ModContent.ItemType<Items.Placeable.Tile.CorruptionBomb>();
                    break;
                case 2:
                    item = ModContent.ItemType<Items.Placeable.Tile.JungleBomb>();
                    break;
                case 3:
                    item = ModContent.ItemType<Items.Placeable.Tile.CrimsonBomb>();
                    break;
                case 4:
                    item = ModContent.ItemType<Items.Placeable.Tile.ContagionBomb>();
                    break;
                case 5:
                    item = ModContent.ItemType<Items.Placeable.Tile.MushroomBomb>();
                    break;
                case 6:
                    item = ModContent.ItemType<Items.Placeable.Tile.HallowBomb>();
                    break;
                case 7:
                    item = ModContent.ItemType<Items.Placeable.Tile.TropicsBomb>();
                    break;
            }
            player.showItemIcon2 = item;
        }
        public override void HitWire(int i, int j)
        {
            int typeC = 2;
            Tile tile = Main.tile[i, j];
            if (tile.frameX <= 52) typeC = 0;
            else if (tile.frameX >= 54 && tile.frameX <= 106) typeC = 1;
            else if (tile.frameX >= 108 && tile.frameX <= 160) typeC = 5;
            else if (tile.frameX >= 162 && tile.frameX <= 214) typeC = 4;
            else if (tile.frameX >= 216 && tile.frameX <= 268) typeC = 6;
            else if (tile.frameX >= 270 && tile.frameX <= 322) typeC = 3;
            else if (tile.frameX >= 324 && tile.frameX <= 376) typeC = 2;
            else if (tile.frameX >= 378 && tile.frameX <= 430) typeC = 7;
            ExxoAvalonOriginsWorld.BCBConvert(i, j, typeC, 75);
            WorldGen.KillTile(i, j, noItem: true);
            if (!Main.tile[i, j].active() && Main.netMode != NetmodeID.SinglePlayer)
            {
                NetMessage.SendData(MessageID.TileChange, -1, -1, null, 0, i, j);
            }
        }
    }
}
