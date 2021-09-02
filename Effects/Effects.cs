using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Effects
{
    class Effects
    {
        public static void Load()
        {
            if (Main.netMode == NetmodeID.Server)
            {
                return;
            }

            Ref<Effect> refOblivionDarkenScreen = new Ref<Effect>(ExxoAvalonOrigins.mod.GetEffect("Effects/OblivionDarkenScreen"));
            Filters.Scene["OblivionDarkenScreen"] = new Filter(new ScreenShaderData(refOblivionDarkenScreen, "OblivionDarkenScreen"), EffectPriority.VeryHigh);
        }
    }
}
