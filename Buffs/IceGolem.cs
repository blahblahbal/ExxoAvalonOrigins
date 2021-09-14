using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;

namespace ExxoAvalonOrigins.Buffs
{
	public class IceGolem : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Ice Golem");
			Description.SetDefault("The ice golem will fight for you");
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int k)
		{
				if (player.ownedProjectileCounts[478] > 0)
				{
					player.GetModPlayer<ExxoAvalonOriginsModPlayer>().iceGolem = true;
				}
				if (!player.GetModPlayer<ExxoAvalonOriginsModPlayer>().iceGolem)
				{
					player.DelBuff(k);
					k--;
				}
				else
				{
					player.buffTime[k] = 18000;
				}
		}
	}
}