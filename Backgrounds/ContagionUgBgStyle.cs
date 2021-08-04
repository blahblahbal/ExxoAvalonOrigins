using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Backgrounds
{
	public class ContagionUgBgStyle : ModUgBgStyle
	{
		public override bool ChooseBgStyle()
		{
			return Main.LocalPlayer.position.Y / 16 < Main.maxTilesY - 390 && Main.LocalPlayer.position.Y / 16 > Main.rockLayer + 90 && Main.LocalPlayer.GetModPlayer<ExxoAvalonOriginsModPlayer>().zoneBooger && !Main.LocalPlayer.ZoneSnow;
		}
		public override void FillTextureArray(int[] textureSlots)
		{
			//textureSlots[0] = mod.GetBackgroundSlot("Backgrounds/ContagionUG0");
			textureSlots[1] = mod.GetBackgroundSlot("Backgrounds/ContagionUG1");
			textureSlots[2] = mod.GetBackgroundSlot("Backgrounds/ContagionUG2");
			textureSlots[3] = mod.GetBackgroundSlot("Backgrounds/ContagionUG3");
			textureSlots[4] = mod.GetBackgroundSlot("Backgrounds/ContagionUG5");
			//textureSlots[5] = mod.GetBackgroundSlot("Backgrounds/ContagionUG4");
		}
	}
}