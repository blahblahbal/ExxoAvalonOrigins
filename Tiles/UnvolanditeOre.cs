using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;using Terraria.ObjectData;using Terraria.Localization;namespace ExxoAvalonOrigins.Tiles{	public class UnvolanditeOre : ModTile	{		public override void SetDefaults()		{			mineResist = 8f;			AddMapEntry(Color.DarkGreen, LanguageManager.Instance.GetText("Unvolandite"));			Main.tileSolid[Type] = true;			Main.tileMergeDirt[Type] = true;            Main.tileSpelunker[Type] = true;            Main.tileValue[Type] = 840;            drop = mod.ItemType("UnvolanditeOre");            soundType = SoundID.Tink;            soundStyle = 1;            minPick = 250;        }        public override bool CanExplode(int i, int j)
        {
            return false;
        }
    }}