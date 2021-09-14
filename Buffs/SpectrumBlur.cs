using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Buffs
{
	public class SpectrumBlur : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Spectrum Blur");
			Description.SetDefault("10% chance to dodge attacks");
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int k)
		{
			player.GetModPlayer<ExxoAvalonOriginsModPlayer>().spectrumBlur = true;
		}
	}
}