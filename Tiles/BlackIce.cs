using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;using Terraria.ObjectData;namespace ExxoAvalonOrigins.Tiles{	public class BlackIce : ModTile	{		public override void SetDefaults()		{			AddMapEntry(new Color(127, 104, 135));			Main.tileSolid[Type] = true;			Main.tileBlockLight[Type] = true;			drop = mod.ItemType("BlackIceBlock");            Main.tileMerge[Type][TileID.IceBlock] = true;
            Main.tileMerge[TileID.IceBlock][Type] = true;			Main.tileShine2[Type] = true;            dustType = DustID.Clentaminator_Purple;            soundType = SoundID.Item;            soundStyle = 50;        }

        public override void KillTile(int i, int j, ref bool fail, ref bool effectOnly, ref bool noItem)
        {
            if (!fail)
            {
                ExxoAvalonOriginsWorld.WorldDarkMatterTiles--;
            }
            base.KillTile(i, j, ref fail, ref effectOnly, ref noItem);
        }
    }}