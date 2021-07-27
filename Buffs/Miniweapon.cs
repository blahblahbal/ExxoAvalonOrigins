using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;using Terraria.DataStructures;namespace ExxoAvalonOrigins.Buffs{	public class Miniweapon : ModBuff	{		public override void SetDefaults()		{			DisplayName.SetDefault("Miniweapons");			Description.SetDefault("The weapons will fight for you");			Main.buffNoTimeDisplay[Type] = true;		}		public override void Update(Player player, ref int k)		{				if (player.ownedProjectileCounts[568] > 0 || player.ownedProjectileCounts[569] > 0 || player.ownedProjectileCounts[570] > 0)				{					player.GetModPlayer<ExxoAvalonOriginsModPlayer>().weaponMinion = true;				}				if (!player.GetModPlayer<ExxoAvalonOriginsModPlayer>().weaponMinion)				{					player.DelBuff(k);					k--;				}				else				{					player.buffTime[k] = 18000;				}		}	}}