using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Waters;

public class TropicsWaterStyle : ModWaterStyle
{
    public override bool ChooseWaterStyle()
    {
        return Main.bgStyle == Mod.GetSurfaceBgStyleSlot("TropicsSurfaceBG");
    }
    //public override bool Autoload(ref string name, ref string texture, ref string blockTexture)
    //{
    //    return true;
    //}
    public override int ChooseWaterfallStyle()
    {
        return Mod.GetWaterfallStyleSlot("TropicsWaterfallStyle");
    }

    public override int GetSplashDust()
    {
        return ModContent.DustType<Dusts.TropicsWaterSplash>();
    }

    public override int GetDropletGore()
    {
        return Mod.Find<ModGore>("Gores/TropicsDroplet");
    }

    public override void LightColorMultiplier(ref float r, ref float g, ref float b)
    {
        r = 1f;
        g = 1f;
        b = 1f;
    }

    public override Color BiomeHairColor()
    {
        return Color.Indigo;
    }
}