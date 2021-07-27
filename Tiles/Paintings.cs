using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace ExxoAvalonOrigins.Tiles
{
    public class Paintings : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileID.Sets.FramesOnKillWall[Type] = true; // Necessary since Style3x3Wall uses AnchorWall
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3Wall);
            TileObjectData.newTile.Width = 6;
            TileObjectData.newTile.Height = 4;
            TileObjectData.newTile.CoordinateHeights = new int[]
            {
                16,
                16,
                16,
                16
            };
            TileObjectData.newTile.AnchorWall = true;
            TileObjectData.addTile(Type);
            dustType = 7;
            disableSmartCursor = true;
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Painting");
            AddMapEntry(new Color(120, 85, 60), name);
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            int item = 0;
            switch (frameY / 72)
            {
                case 0:
                    item = ModContent.ItemType<Items.EclipseofDoom>();
                    break;
                case 1:
                    item = ModContent.ItemType<Items.RuinedCivilization>();
                    break;
                case 2:
                    item = ModContent.ItemType<Items.Trespassing>();
                    break;
                case 3:
                    item = ModContent.ItemType<Items.BirthofaMonster>();
                    break;
                case 4:
                    item = ModContent.ItemType<Items.EvilOuroboros>();
                    break;
                case 5:
                    item = ModContent.ItemType<Items.ACometHasStruckGround>();
                    break;
                case 6:
                    item = ModContent.ItemType<Items.PlanterasRage>();
                    break;
                case 7:
                    item = ModContent.ItemType<Items.FightoftheBumblebee>();
                    break;
                case 8:
                    item = ModContent.ItemType<Items.FrostySpectacle>();
                    break;
                case 9:
                    item = ModContent.ItemType<Items.RingofDisgust>();
                    break;
                //case 10:
                //    item = ModContent.ItemType<Items.CurseofOblivion>();
                //    break;
                //case 11:
                //    item = ModContent.ItemType<Items.Clash>();
                //    break;
            }
            if (item > 0)
            {
                Item.NewItem(i * 16, j * 16, 48, 48, item);
            }
        }
    }
}
