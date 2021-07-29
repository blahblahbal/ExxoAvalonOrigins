using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Waters
{
    public class ContagionWater : ModWaterStyle
    {
        public override bool ChooseWaterStyle()
            => Main.bgStyle == mod.GetSurfaceBgStyleSlot("ContagionSurfaceBG");

        public override int ChooseWaterfallStyle()
            => mod.GetWaterfallStyleSlot("ContagionWaterfallStyle");

        public override int GetSplashDust()
            => ModContent.DustType<Dusts.ContagionWaterSplash>();

        public override int GetDropletGore()
            => mod.GetGoreSlot("Gores/ContagionDroplet");

        public override void LightColorMultiplier(ref float r, ref float g, ref float b)
        {
            r = 1f;
            g = 1f;
            b = 1f;
        }

        public override Color BiomeHairColor()
            => Color.Lime;
    }
}