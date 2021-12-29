using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.ObjectData;
using Terraria.Localization;

namespace ExxoAvalonOrigins.Tiles
{
	public class VorazylcumOre : ModTile
	{
		public override void SetDefaults()
		{
			mineResist = 8f;
			AddMapEntry(new Color(140, 130, 196), LanguageManager.Instance.GetText("Vorazylcum"));
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
            Main.tileSpelunker[Type] = true;
            Main.tileValue[Type] = 850;
            Main.tileBlockLight[Type] = true;
            Main.tileShine2[Type] = true;
            Main.tileShine[Type] = 1900;
            drop = mod.ItemType("VorazylcumOre");
            soundType = SoundID.Tink;
            soundStyle = 1;
            minPick = 250;
            dustType = DustID.VilePowder;
        }
        public override bool CanExplode(int i, int j)
        {
            return false;
        }
        public override void NearbyEffects(int i, int j, bool closer)
        {
            if (Main.rand.Next(1500) == 0)
            {
                NPC.NewNPC(i * 16, j * 16, ModContent.NPCType<NPCs.VorazylcumMiteDigger>());
            }
        }
    }
}
