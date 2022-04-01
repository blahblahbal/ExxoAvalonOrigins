using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace ExxoAvalonOrigins.Tiles
{
    public class ResistantWoodClock : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = false;
            TileID.Sets.HasOutlines[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
            TileObjectData.newTile.Height = 5;
            TileObjectData.newTile.CoordinateHeights = new int[]
            {
                16,
                16,
                16,
                16,
                16
            };
            TileObjectData.newTile.Origin = new Point16(0, 4);
            TileObjectData.addTile(Type);
            var name = CreateMapEntryName();
            name.SetDefault("Resistant Wood Clock");
            AddMapEntry(new Color(191, 142, 111), name);
            disableSmartCursor = true;
            adjTiles = new int[] { TileID.GrandfatherClocks };
            dustType = DustID.Wraith;
        }

        public override bool HasSmartInteract()
        {
            return true;
        }

        public override void MouseOver(int i, int j)
        {
            var player = Main.player[Main.myPlayer];
            player.noThrow = 2;
            player.showItemIcon = true;
            player.showItemIcon2 = ModContent.ItemType<Items.Placeable.Furniture.ResistantWoodClock>();
        }

        public override void RightClick(int x, int y)
        {
            {
                var text = "AM";
                var time = Main.time;
                if (!Main.dayTime)
                {
                    time += 54000.0;
                }
                time = time / 86400.0 * 24.0;
                time = time - 7.5 - 12.0;
                if (time < 0.0)
                {
                    time += 24.0;
                }
                if (time >= 12.0)
                {
                    text = "PM";
                }
                var intTime = (int)time;
                var deltaTime = time - intTime;
                deltaTime = ((int)(deltaTime * 60.0));
                var text2 = string.Concat(deltaTime);
                if (deltaTime < 10.0)
                {
                    text2 = "0" + text2;
                }
                if (intTime > 12)
                {
                    intTime -= 12;
                }
                if (intTime == 0)
                {
                    intTime = 12;
                }
                var newText = string.Concat("Time: ", intTime, ":", text2, " ", text);
                Main.NewText(newText, 255, 240, 20);
            }
        }

        public override void NearbyEffects(int i, int j, bool closer)
        {
            if (closer)
            {
                Main.clock = true;
            }
        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(i * 16, j * 16, 48, 32, ModContent.ItemType<Items.Placeable.Furniture.ResistantWoodClock>());
        }
    }
}
