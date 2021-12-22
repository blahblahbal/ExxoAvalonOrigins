using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories
{
	[AutoloadEquip(EquipType.Shield)]
	class TitanShield : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Titan Shield");
			Tooltip.SetDefault("+15 defense, +3 life regeneration, +15% damage | Absorbs 25% of damage done to players on\nEffects are only active when below 33% health  | your team (only active above 25% life)");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.defense = 12;
			item.rare = ItemRarityID.Red;
			item.width = dims.Width;
			item.value = Item.sellPrice(0, 50, 0, 0);
			item.accessory = true;
			item.height = dims.Height;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			if (player.statLife <= player.statLifeMax2 * 0.33)
			{
				player.statDefense += 20;
				player.lifeRegen += 5;
				player.magicDamage += 0.2f;
				player.meleeDamage += 0.2f;
				player.minionDamage += 0.2f;
				player.rangedDamage += 0.2f;
			}
			player.noKnockback = true;
			if (player.statLife > player.statLifeMax2 * 0.25)
			{
				player.hasPaladinShield = true;
				if (player.miscCounter % 5 == 0)
				{
					var myPlayer = Main.myPlayer;
					if (Main.player[myPlayer].team == player.team && player.team != 0)
					{
						var num45 = player.position.X - Main.player[myPlayer].position.X;
						var num46 = player.position.Y - Main.player[myPlayer].position.Y;
						var num47 = (float)Math.Sqrt(num45 * num45 + num46 * num46);
						if (num47 < 800f)
						{
							Main.player[myPlayer].AddBuff(43, 10, true);
						}
					}
				}
			}
		}
	}
}