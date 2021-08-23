using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;using Terraria.ObjectData;namespace ExxoAvalonOrigins.Tiles{	public class Phantoplasm : ModTile	{		public override void SetDefaults()		{			AddMapEntry(Color.Red);			Main.tileSolid[Type] = true;			drop = mod.ItemType("Phantoplasm");            dustType = DustID.TheDestoryer;
        }        public override bool KillSound(int i, int j)
        {
            if (Main.rand.Next(10) == 0) Main.PlaySound(SoundID.NPCKilled, i * 16, j * 16, 6);
            return true;
        }
    }}