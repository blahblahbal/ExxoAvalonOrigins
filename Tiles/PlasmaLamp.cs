using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;using Terraria.ObjectData;namespace ExxoAvalonOrigins.Tiles{	public class PlasmaLamp : ModTile	{		public override void SetDefaults()		{
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);			//TileObjectData.newTile.CoordinateHeights = new int[] {16, 16};			//TileObjectData.newTile.CoordinatePadding = 2;			//TileObjectData.newTile.DrawYOffset = 2;			//TileObjectData.newTile.StyleHorizontal = true;			TileObjectData.addTile(Type);			Main.tileLighted[Type] = true;			Main.tileFrameImportant[Type] = true;		}        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)        {            r = 0.6f;            g = 0.1f;            b = 0.6f;        }        public override void AnimateTile(ref int frame, ref int frameCounter)
        {
            frameCounter++;
            if (frameCounter > 5)
            {
                frameCounter = 0;
                frame++;
                if (frame > 3) frame = 0;
            }
            //frame = Main.tileFrame[TileID.AdamantiteForge];
        }        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(i * 16, j * 16, 48, 32, ModContent.ItemType<Items.PlasmaLamp>());
        }    }}