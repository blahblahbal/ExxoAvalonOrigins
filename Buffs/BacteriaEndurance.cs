﻿using Terraria;
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
			Description.SetDefault("Thorns effect and increased damage and jump speed");
		}
		
		public override void Update(Player player, ref int k)
		{
			player.thorns += 0.8f; //effects of this will mostlikely change
            player.jumpSpeedBoost += 0.2f;

		}
	}
}