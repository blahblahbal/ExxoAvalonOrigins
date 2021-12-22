using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Logic
{
    public static class CanBeFrozen
    {
        public static bool CanFreeze(NPC npc)
        {
            int lifeThreshold;
            if (ModContent.GetInstance<ExxoAvalonOriginsWorld>().SuperHardmode)
            {
                lifeThreshold = 11000;
            }
            else if (Main.hardMode)
            {
                lifeThreshold = 5000;
            }
            else // Prehardmode
            {
                lifeThreshold = 300;
            }

            return npc.lifeMax <= lifeThreshold && !npc.boss && !npc.dontTakeDamage;
        }
    }
}
