using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ExxoAvalonOrigins.Items
{
	[AutoloadEquip(EquipType.HandsOn, EquipType.HandsOff)]
	class FrostGauntlet : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Frost Gauntlet");
			Tooltip.SetDefault("Melee attacks inflict Frostburn and increases damage and melee speed by 9%\nIncreases knockback and puts a damage-reducing shell around the holder when below 25% life");
		}

		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/FrostGauntlet");
			item.rare = ItemRarityID.Lime;
			item.width = dims.Width;
			item.accessory = true;
			item.value = Item.sellPrice(0, 10, 0, 0);
			item.height = dims.Height;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			if (player.statLife <= player.statLifeMax2 * 0.25)
			{
				player.AddBuff(62, 5, true);
			}
			player.frostBurn = true;
			player.kbGlove = true;
			player.meleeSpeed += 0.1f;
			player.meleeDamage += 0.1f;
			player.rangedDamage += 0.1f;
			player.frostArmor = true;
		}
	}
}