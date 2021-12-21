using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;

namespace ExxoAvalonOrigins.Effects
{
    public static class EffectsManager
    {
        public const string SceneKeyOblivionDarkenScreen = "OblivionDarkenScreen";
        public static void Load()
        {
            if (Main.netMode == NetmodeID.Server)
            {
                return;
            }

            var refOblivionDarkenScreen = new Ref<Effect>(ExxoAvalonOrigins.mod.GetEffect("Effects/OblivionDarkenScreen"));
            Filters.Scene[SceneKeyOblivionDarkenScreen] = new Filter(new ScreenShaderData(refOblivionDarkenScreen, SceneKeyOblivionDarkenScreen), EffectPriority.VeryHigh);
        }
    }
}
