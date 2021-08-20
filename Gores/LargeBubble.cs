using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Gores
{
    public class LargeBubble : ModGore
    {
        public override bool Update(Gore gore)
        {
            if (gore.timeLeft == 0) gore.alpha = 255;
            return true;
        }
    }
}