using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;using Terraria.DataStructures;namespace ExxoAvalonOrigins.Buffs{	public class CurseofIcarus : ModBuff	{		public override void SetDefaults()		{			DisplayName.SetDefault("Curse of Icarus");			Description.SetDefault("'Your wings are broken'");			Main.debuff[Type] = true;			Main.buffNoTimeDisplay[Type] = true;
			Main.buffNoSave[Type] = true;		}		public override void Update(Player player, ref int k)		{
			player.GetModPlayer<ExxoAvalonOriginsModPlayer>().curseOfIcarus = true;
		}
	}
}