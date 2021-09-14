using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Buffs.AdvancedBuffs
{
	public class AdvFury : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Advanced Fury");
			Description.SetDefault("40% increased critical damage");
		}

		public override void Update(Player player, ref int k)
		{
			player.GetModPlayer<ExxoAvalonOriginsModPlayer>().critDamageMult += 0.4f;
		}
	}
}