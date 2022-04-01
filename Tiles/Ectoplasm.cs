using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace ExxoAvalonOrigins.Tiles
{
    public class Ectoplasm : ModTile
    {
        public override void SetStaticDefaults()
        {
            AddMapEntry(new Color(27, 194, 254));
            Main.tileSolid[Type] = true;
            Main.tileLargeFrames[Type] = 1;
            Main.tileBlockLight[Type] = true;
            Main.tileLighted[Type] = true;
            drop = ItemID.Ectoplasm;
            soundType = SoundID.NPCHit;
            soundStyle = 1;
            dustType = DustID.Ultrabright;
        }
        public override bool KillSound(int i, int j)
        {
            if (Main.rand.Next(10) == 0) SoundEngine.PlaySound(SoundID.NPCKilled, i * 16, j * 16, 6);
            return true;
        }

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            r = 0.16f;
            g = 0.2f;
            b = 0.3f;
        }
    }
}