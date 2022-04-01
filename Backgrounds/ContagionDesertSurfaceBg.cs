using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Backgrounds
{
    public class ContagionDesertSurfaceBg : ModSurfaceBgStyle
    {
        public override bool ChooseBgStyle()
        {
            return !Main.gameMenu && Main.LocalPlayer.Avalon().ZoneBooger && Main.LocalPlayer.ZoneDesert;
        }

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

        public override int ChooseFarTexture()
        {
            return Mod.GetBackgroundSlot("Backgrounds/ContagionDesertSurfaceBg3");
        }

        public override int ChooseMiddleTexture()
        {
            return Mod.GetBackgroundSlot("Backgrounds/ContagionDesertSurfaceBg2");
        }

        public override int ChooseCloseTexture(ref float scale, ref double parallax, ref float a, ref float b)
        {
            return Mod.GetBackgroundSlot("Backgrounds/ContagionDesertSurfaceBg1");
        }
    }
}