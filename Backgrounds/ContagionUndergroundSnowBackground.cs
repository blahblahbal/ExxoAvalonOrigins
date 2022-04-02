using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Backgrounds;

public class ContagionUndergroundSnowBackground : ModUndergroundBackgroundStyle
{
    public override void FillTextureArray(int[] textureSlots)
    {
        textureSlots[1] = BackgroundTextureLoader.GetBackgroundSlot("Backgrounds/ContagionUndergroundSnowBackground1");
        textureSlots[2] = BackgroundTextureLoader.GetBackgroundSlot("Backgrounds/ContagionUndergroundSnowBackground2");
        textureSlots[3] = BackgroundTextureLoader.GetBackgroundSlot("Backgrounds/ContagionUndergroundSnowBackground3");
        textureSlots[4] = BackgroundTextureLoader.GetBackgroundSlot("Backgrounds/ContagionUndergroundSnowBackground4");
    }
}
