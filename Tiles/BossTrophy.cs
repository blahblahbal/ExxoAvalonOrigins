using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace ExxoAvalonOrigins.Tiles
{
    public class BossTrophy : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileID.Sets.FramesOnKillWall[Type] = true; // Necessary since Style3x3Wall uses AnchorWall
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3Wall);
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.StyleWrapLimit = 36;
            TileObjectData.addTile(Type);
            dustType = 7;
            disableSmartCursor = true;
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Trophy");
            AddMapEntry(new Color(120, 85, 60), name);
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            int item = 0;
            switch (frameX / 54)
            {
                case 0:
                    item = ModContent.ItemType<Items.DesertBeakTrophy>();
                    break;
                case 1:
                    item = ModContent.ItemType<Items.ArmageddonSlimeTrophy>();
                    break;
                case 2:
                    item = ModContent.ItemType<Items.DragonLordTrophy>();
                    break;
                case 3:
                    item = ModContent.ItemType<Items.OblivionTrophy>();
                    break;
                case 4:
                    item = ModContent.ItemType<Items.BacteriumPrimeTrophy>();
                    break;
                case 5:
                    item = ModContent.ItemType<Items.EggmanTrophy>();
                    break;
            }
            if (item > 0)
            {
                Item.NewItem(i * 16, j * 16, 48, 48, item);
            }
        }
    }
}
