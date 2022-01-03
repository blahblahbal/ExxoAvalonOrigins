using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System.Collections.Generic;

namespace ExxoAvalonOrigins.Buffs
{
	public class BacteriaEndurence : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Bacteria Thorns");
			Description.SetDefault("Almost feels like little bacteria defending you."); 
		}
		
		public override void Update(Player player, ref int k)
		{
			player.thorns += 0.8f; //effects of this will mostlikely change
		}
	}
}