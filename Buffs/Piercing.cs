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
	public class Piercing : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Piercing");
			Description.SetDefault("Projectile penetration is increased");
		}

		public override void Update(Player player, ref int k)
		{
			
		}
	}
}
