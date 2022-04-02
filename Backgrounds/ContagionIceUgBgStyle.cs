using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Backgrounds;

public class ContagionIceUgBgStyle : ModUgBgStyle
{
    public override bool ChooseBgStyle()
    {
        return Main.LocalPlayer.position.Y / 16 < Main.maxTilesY - 390 && Main.LocalPlayer.position.Y / 16 > Main.rockLayer + 90 && ExxoAvalonOriginsWorld.ickyTiles > 200 && Main.LocalPlayer.ZoneSnow;
    }
    public override void FillTextureArray(int[] textureSlots)
    {
        //textureSlots[0] = mod.GetBackgroundSlot("Backgrounds/ContagionUG0");
        textureSlots[1] = Mod.GetBackgroundSlot("Backgrounds/ContagionIceUG1");
        textureSlots[2] = Mod.GetBackgroundSlot("Backgrounds/ContagionIceUG2");
        textureSlots[3] = Mod.GetBackgroundSlot("Backgrounds/ContagionIceUG3");
        textureSlots[4] = Mod.GetBackgroundSlot("Backgrounds/ContagionIceUG5");
        //textureSlots[5] = mod.GetBackgroundSlot("Backgrounds/ContagionUG4");
    }
}