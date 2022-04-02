using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Backgrounds;

public class TropicsSurfaceBgStyle : ModSurfaceBgStyle
{
    public override bool ChooseBgStyle()
    {
        return !Main.gameMenu && !Main.LocalPlayer.ZoneCrimson && !Main.LocalPlayer.ZoneCorrupt && Main.LocalPlayer.Avalon().ZoneTropics;
    }

    // Use this to keep far Backgrounds like the mountains.
    // This shit doesn't work. Why?
    public override void ModifyFarFades(float[] fades, float transitionSpeed)
    {
        for (int i = 0; i < fades.Length; i++)
        {
            if (i == Slot)
            {
                fades[i] += transitionSpeed;
                if (fades[i] > 1f)
                {
                    fades[i] = 1f;
                }
            }
            else
            {
                fades[i] -= transitionSpeed;
                if (fades[i] < 0f)
                {
                    fades[i] = 0f;
                }
            }
        }
    }

    // Also this displays too low down.
    public override int ChooseFarTexture()
    {
        return Mod.GetBackgroundSlot("Backgrounds/TropicsSurfaceBG3");
    }

    private static int SurfaceFrameCounter;
    private static int SurfaceFrame;
    public override int ChooseMiddleTexture()
    {
        if (++SurfaceFrameCounter > 12)
        {
            SurfaceFrame = (SurfaceFrame + 1) % 4;
            SurfaceFrameCounter = 0;
        }
        return Mod.GetBackgroundSlot("Backgrounds/TropicsSurfaceBG2");
    }

    public override int ChooseCloseTexture(ref float scale, ref double parallax, ref float a, ref float b)
    {
        b -= 200;
        return Mod.GetBackgroundSlot("Backgrounds/TropicsSurfaceBG");
    }
}