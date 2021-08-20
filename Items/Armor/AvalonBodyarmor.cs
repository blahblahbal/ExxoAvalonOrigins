using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ExxoAvalonOrigins.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    class AvalonBodyarmor : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Avalon Bodyarmor");
			Tooltip.SetDefault("Increased life regeneration"
				+ "\nGreatly increases length of invincibility after taking damage"
				+ "\nThe wearer can double jump"
				+ "\nCrystal skull effect"
				+ "\nIncreases maximum mana by 80"
				+ "\n3% increased critical strike chance and 30% increased critical strike damage"
				+ "\nStars fall when injured");
		}

		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/Armor/AvalonBodyarmor");
			item.defense = 40;
			item.rare = ItemRarityID.Yellow;
			item.width = dims.Width;
			item.value = Item.sellPrice(0, 41, 0, 0);
			item.height = dims.Height;
		}

		public override void UpdateEquip(Player player)
		{
			int i2 = (int)(player.position.X + (float)(player.width / 2) + (float)(8 * player.direction)) / 16;
			int j2 = (int)(player.position.Y + 2f) / 16;
			Lighting.AddLight(i2, j2, 2.5f, 2.5f, 2.5f);
			player.lifeRegen += 1;
			player.starCloak = true;
			player.longInvince = true;
			player.findTreasure = true;
			player.detectCreature = true;
			player.statManaMax2 += 80;
			player.doubleJumpCloud = true;
			player.magicCrit += 3;
			player.meleeCrit += 3;
			player.rangedCrit += 3;
			player.thrownCrit += 3;
			player.GetModPlayer<ExxoAvalonOriginsModPlayer>().critDamageMult += 0.30f;
		}
	}
}
