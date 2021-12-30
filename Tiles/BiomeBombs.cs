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
            switch (frameX / 54)
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
            //WorldGen.KillTile(i, j, noItem: true);
            for (int x = i - 1; x <= i + 1; x++)
            {
                for (int y = j - 1; y <= j; y++)
                {
                    Main.tile[x, y].active(false);
                    if (!Main.tile[x, y].active() && Main.netMode != NetmodeID.SinglePlayer)
                    {
                        NetMessage.SendData(MessageID.TileChange, -1, -1, null, 0, x, y);
                    }
                    for (int num369 = 0; num369 < 3; num369++)
                    {
                        int num370 = Dust.NewDust(new Vector2(x * 16, y * 16), 8, 8, DustID.Smoke, 0f, 0f, 100, default, 1.5f);
                        Main.dust[num370].velocity *= 1.4f;
                    }
                    for (int num371 = 0; num371 < 3; num371++)
                    {
                        int num372 = Dust.NewDust(new Vector2(x * 16, y * 16), 8, 8, DustID.Fire, 0f, 0f, 100, default, 2.5f);
                        Main.dust[num372].noGravity = true;
                        Main.dust[num372].velocity *= 5f;
                        num372 = Dust.NewDust(new Vector2(x * 16, y * 16), 8, 8, DustID.Fire, 0f, 0f, 100, default, 1.5f);
                        Main.dust[num372].velocity *= 3f;
                    }
                }
            }
            Main.PlaySound(2, i * 16, j * 16, 14);
            return true;
        }
        public override void MouseOver(int i, int j)
        {
            Player player = Main.LocalPlayer;
            player.noThrow = 2;
            player.showItemIcon = true;
            int item = 0;
            Tile tile = Main.tile[i, j];
            if (tile.frameX <= 52) item = ModContent.ItemType<Items.Placeable.Tile.PurityBomb>();
            else if (tile.frameX >= 54 && tile.frameX <= 106) item = ModContent.ItemType<Items.Placeable.Tile.CorruptionBomb>();
            else if (tile.frameX >= 108 && tile.frameX <= 160) item = ModContent.ItemType<Items.Placeable.Tile.JungleBomb>();
            else if (tile.frameX >= 162 && tile.frameX <= 214) item = ModContent.ItemType<Items.Placeable.Tile.CrimsonBomb>();
            else if (tile.frameX >= 216 && tile.frameX <= 268) item = ModContent.ItemType<Items.Placeable.Tile.ContagionBomb>();
            else if (tile.frameX >= 270 && tile.frameX <= 322) item = ModContent.ItemType<Items.Placeable.Tile.MushroomBomb>();
            else if (tile.frameX >= 324 && tile.frameX <= 376) item = ModContent.ItemType<Items.Placeable.Tile.HallowBomb>();
            else if (tile.frameX >= 378 && tile.frameX <= 430) item = ModContent.ItemType<Items.Placeable.Tile.TropicsBomb>();
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
            //WorldGen.KillTile(i, j, noItem: true);
            for (int x = i - 1; x <= i + 1; x++)
            {
                for (int y = j - 1; y <= j; y++)
                {
                    Main.tile[x, y].active(false);
                    if (!Main.tile[x, y].active() && Main.netMode != NetmodeID.SinglePlayer)
                    {
                        NetMessage.SendData(MessageID.TileChange, -1, -1, null, 0, x, y);
                    }
                    for (int num369 = 0; num369 < 3; num369++)
                    {
                        int num370 = Dust.NewDust(new Vector2(x * 16, y * 16), 8, 8, DustID.Smoke, 0f, 0f, 100, default, 1.5f);
                        Main.dust[num370].velocity *= 1.4f;
                    }
                    for (int num371 = 0; num371 < 3; num371++)
                    {
                        int num372 = Dust.NewDust(new Vector2(x * 16, y * 16), 8, 8, DustID.Fire, 0f, 0f, 100, default, 2.5f);
                        Main.dust[num372].noGravity = true;
                        Main.dust[num372].velocity *= 5f;
                        num372 = Dust.NewDust(new Vector2(x * 16, y * 16), 8, 8, DustID.Fire, 0f, 0f, 100, default, 1.5f);
                        Main.dust[num372].velocity *= 3f;
                    }
                }
            }
            Main.PlaySound(2, i * 16, j * 16, 14);
        }
    }
}
