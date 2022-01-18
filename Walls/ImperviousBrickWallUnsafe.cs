using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Walls
{
    public class ImperviousBrickWallUnsafe : ModWall
    {
        public override void SetDefaults()
        {
            Main.wallHouse[Type] = false;
            AddMapEntry(new Color(51, 44, 48));
            drop = mod.ItemType("ImperviousBrickWall");
            dustType = DustID.Wraith;
        }
        public override void KillWall(int i, int j, ref bool fail)
        {
            if (!ExxoAvalonOriginsWorld.downedPhantasm) fail = true;
        }
    }
}