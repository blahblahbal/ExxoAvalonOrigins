using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System.Collections.Generic;

namespace ExxoAvalonOrigins.Buffs
{
	public class BacteriaEndurance : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Bacterial Endurance");
			Description.SetDefault("Almost feels like little bacteria defending you.");
		}
		
		public override void Update(Player player, ref int k)
		{
			player.thorns += 0.8f; //effects of this will mostlikely change
            player.endurance += 0.25f;
		}
	}
}
