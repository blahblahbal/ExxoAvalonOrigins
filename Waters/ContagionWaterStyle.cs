using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Waters
{
    public class ContagionWaterStyle : ModWaterStyle
    {
        public override bool ChooseWaterStyle()
        {
            return Main.bgStyle == mod.GetSurfaceBgStyleSlot("ContagionSurfaceBG");
        }
        //public override bool Autoload(ref string name, ref string texture, ref string blockTexture)
        //{
        //    return true;
        //}
        public override int ChooseWaterfallStyle()
        {
            return mod.GetWaterfallStyleSlot("ContagionWaterfallStyle");
        }

        public override int GetSplashDust()
        {
            return ModContent.DustType<Dusts.ContagionWaterSplash>();
        }

        public override int GetDropletGore()
        {
            return mod.GetGoreSlot("Gores/ContagionDroplet");
        }

        public override void LightColorMultiplier(ref float r, ref float g, ref float b)
        {
            r = 1f;
            g = 1f;
            b = 1f;
        }

        public override Color BiomeHairColor()
        {
            return Color.Lime;
        }
    }
}