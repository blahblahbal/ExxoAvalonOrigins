using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;using Terraria.ObjectData;namespace ExxoAvalonOrigins.Tiles{
    public class PlacedBars : ModTile
    {        public override void SetDefaults()        {            TileObjectData.newTile.Width = 1;
            TileObjectData.newTile.Height = 1;
            TileObjectData.newTile.CoordinateWidth = 16;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16 };
            TileObjectData.newTile.CoordinatePadding = 2;
            //TileObjectData.newTile.DrawYOffset = 2;
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.addTile(Type);            Main.tileFrameImportant[Type] = true;            Main.tileObsidianKill[Type] = true;            Main.tileSolidTop[Type] = true;            Main.tileSolid[Type] = true;            Main.tileShine[Type] = 1100;        }

        // selects the map entry depending on the frameX
        public override ushort GetMapOption(int i, int j)        {            return (ushort)(Main.tile[i, j].frameX / 18);        }        public override void KillTile(int i, int j, ref bool fail, ref bool effectOnly, ref bool noItem)
        {            var toDrop = 0;            switch (Main.tile[i, j].frameX / 18)            {                case 0:                    toDrop = ModContent.ItemType<Items.CaesiumBar>();                    break;                case 1:                    toDrop = ModContent.ItemType<Items.OblivionBar>();                    break;                case 2:                    toDrop = ModContent.ItemType<Items.HydrolythBar>();                    break;                case 3:                    toDrop = ModContent.ItemType<Items.RhodiumBar>();                    break;                case 4:                    toDrop = ModContent.ItemType<Items.OsmiumBar>();                    break;                case 5:                    toDrop = ModContent.ItemType<Items.FeroziumBar>();                    break;                case 6:                    toDrop = ModContent.ItemType<Items.UnvolanditeBar>();                    break;                case 7:                    toDrop = ModContent.ItemType<Items.VorazylcumBar>();                    break;                case 8:                    toDrop = ModContent.ItemType<Items.TritanoriumBar>();                    break;
                case 9:                    toDrop = ModContent.ItemType<Items.DurataniumBar>();                    break;
                case 10:                    toDrop = ModContent.ItemType<Items.NaquadahBar>();                    break;
                case 11:                    toDrop = ModContent.ItemType<Items.TroxiniumBar>();                    break;
                case 12:                    toDrop = ModContent.ItemType<Items.BacciliteBar>();                    break;
                case 13:                    toDrop = ModContent.ItemType<Items.PyroscoricBar>();                    break;
                case 14:                    toDrop = ModContent.ItemType<Items.BeetleBar>();                    break;
                case 15:                    toDrop = ModContent.ItemType<Items.SuperhardmodeBar>();                    break;
                case 16:                    toDrop = ModContent.ItemType<Items.EnchantedBar>();                    break;
                case 17:                    toDrop = ModContent.ItemType<Items.BerserkerBar>();                    break;
                case 18:                    toDrop = ModContent.ItemType<Items.BronzeBar>();                    break;
                case 19:                    toDrop = ModContent.ItemType<Items.NickelBar>();                    break;
                case 20:                    toDrop = ModContent.ItemType<Items.ZincBar>();                    break;
                case 21:                    toDrop = ModContent.ItemType<Items.BismuthBar>();                    break;
                case 22:                    toDrop = ModContent.ItemType<Items.IridiumBar>();                    break;            }            Item.NewItem(i * 16, j * 16, 16, 16, toDrop);
        }    }}