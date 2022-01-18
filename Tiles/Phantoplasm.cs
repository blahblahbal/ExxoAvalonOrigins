using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Tiles
{
    public class Phantoplasm : ModTile
    {
        public override void SetDefaults()
        {
            AddMapEntry(Color.Red);
            Main.tileSolid[Type] = true;
            drop = mod.ItemType("Phantoplasm");
            dustType = DustID.TheDestoryer;
        }
        public override bool KillSound(int i, int j)
        {
            if (Main.rand.Next(10) == 0) Main.PlaySound(SoundID.NPCKilled, i * 16, j * 16, 6);
            return true;
        }
    }
}