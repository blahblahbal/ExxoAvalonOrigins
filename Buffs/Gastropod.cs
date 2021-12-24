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
	public class Gastropod : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Gastropod");
			Description.SetDefault("The gastropod will fight for you");
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int k)
		{
            if (player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.GastrominiSummon>()] > 0)
            {
                player.GetModPlayer<ExxoAvalonOriginsModPlayer>().gastroMinion= true;
            }
            if (!player.GetModPlayer<ExxoAvalonOriginsModPlayer>().gastroMinion)
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
