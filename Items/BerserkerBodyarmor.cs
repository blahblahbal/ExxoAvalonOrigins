using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;namespace ExxoAvalonOrigins.Items{	[AutoloadEquip(EquipType.Body)]	class BerserkerBodyarmor : ModItem	{		public override void SetStaticDefaults()		{			DisplayName.SetDefault("Berserker Bodyarmor");			Tooltip.SetDefault("Enemies are more likely to target you\nAttackers also take full damage");		}		public override void SetDefaults()		{			Rectangle dims = ExxoAvalonOrigins.getDims("Items/BerserkerBodyarmor");			item.defense = 42;			item.rare = 10;			item.width = dims.Width;			item.value = Item.sellPrice(0, 60, 0, 0);			item.height = dims.Height;		}		public override void UpdateEquip(Player player)		{			player.aggro += 600;			//player.thorns = true;			player.turtleThorns = true;		}	}}