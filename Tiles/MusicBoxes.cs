using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace ExxoAvalonOrigins.Tiles
{
    internal class MusicBoxes : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileObsidianKill[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
            TileObjectData.newTile.Origin = new Point16(0, 1);
            TileObjectData.newTile.LavaDeath = false;
            TileObjectData.newTile.DrawYOffset = 2;
            TileObjectData.addTile(Type);
            disableSmartCursor = true;
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Music Box");
            AddMapEntry(new Color(200, 200, 200), name);
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            int item = 0;
            switch (frameY / 36)
            {
                case 0:
                    item = ModContent.ItemType<Items.MusicBoxes.MusicBoxContagion>();
                    break;
                case 1:
                    item = ModContent.ItemType<Items.MusicBoxes.MusicBoxBacteriumPrime>();
                    break;
                case 2:
                    item = ModContent.ItemType<Items.MusicBoxes.MusicBoxArmageddonSlime>();
                    break;
                case 3:
                    item = ModContent.ItemType<Items.MusicBoxes.MusicBoxDesertBeak>();
                    break;
                case 4:
                    item = ModContent.ItemType<Items.MusicBoxes.MusicBoxUndergroundContagion>();
                    break;
                case 5:
                    item = ModContent.ItemType<Items.MusicBoxes.MusicBoxTropics>();
                    break;
                case 6:
                    item = ModContent.ItemType<Items.MusicBoxes.MusicBoxPhantasm>();
                    break;
                /*case 7:
				    item = ModContent.ItemType<Items.MusicBoxes.MusicBoxDarkMatter>();
					break;*/
                case 8:
                    item = ModContent.ItemType<Items.MusicBoxes.MusicBoxHellCastle>();
                    break;
                case 9:
                    item = ModContent.ItemType<Items.MusicBoxes.MusicBoxTuhrtlOutpost>();
                    break;
            }
            Item.NewItem(i * 16, j * 16, 16, 48, item);
        }

        public override void MouseOver(int i, int j)
        {
            int item = 0;
            switch (Main.tile[i, j].frameY / 36)
            {
                case 0:
                    item = ModContent.ItemType<Items.MusicBoxes.MusicBoxContagion>();
                    break;
                case 1:
                    item = ModContent.ItemType<Items.MusicBoxes.MusicBoxBacteriumPrime>();
                    break;
                case 2:
                    item = ModContent.ItemType<Items.MusicBoxes.MusicBoxArmageddonSlime>();
                    break;
                case 3:
                    item = ModContent.ItemType<Items.MusicBoxes.MusicBoxDesertBeak>();
                    break;
                case 4:
                    item = ModContent.ItemType<Items.MusicBoxes.MusicBoxUndergroundContagion>();
                    break;
                case 5:
                    item = ModContent.ItemType<Items.MusicBoxes.MusicBoxTropics>();
                    break;
                case 6:
                    item = ModContent.ItemType<Items.MusicBoxes.MusicBoxPhantasm>();
                    break;
                /*case 7:
				    item = ModContent.ItemType<Items.MusicBoxes.MusicBoxDarkMatter>();
					break;*/
                case 8:
                    item = ModContent.ItemType<Items.MusicBoxes.MusicBoxHellCastle>();
                    break;
                case 9:
                    item = ModContent.ItemType<Items.MusicBoxes.MusicBoxTuhrtlOutpost>();
                    break;
            }
            Player player = Main.LocalPlayer;
            player.noThrow = 2;
            player.showItemIcon = true;
            player.showItemIcon2 = item;
        }
    }
}