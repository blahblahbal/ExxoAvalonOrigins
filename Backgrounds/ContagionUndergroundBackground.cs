using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Backgrounds;

public class ContagionUndergroundBackground : ModUndergroundBackgroundStyle
{
    public override void FillTextureArray(int[] textureSlots)
    {
        textureSlots[1] = BackgroundTextureLoader.GetBackgroundSlot("Backgrounds/ContagionUndergroundBackground1");
        textureSlots[2] = BackgroundTextureLoader.GetBackgroundSlot("Backgrounds/ContagionUndergroundBackground2");
        textureSlots[3] = BackgroundTextureLoader.GetBackgroundSlot("Backgrounds/ContagionUndergroundBackground3");
        textureSlots[4] = BackgroundTextureLoader.GetBackgroundSlot("Backgrounds/ContagionUndergroundBackground4");
    }
}
