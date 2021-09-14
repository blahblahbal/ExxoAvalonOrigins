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
	[AutoloadEquip(EquipType.Body)]
	class AwakenedRosePlateMail : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Awakened Rose Plate Mail");
			Tooltip.SetDefault("Press V to teleport to the cursor"
				+ "\nOn hitting tiles with a magic attack, there is a chance a small vine of thorns shoots out of the ground");
		}

		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/AwakenedRosePlateMail");
			item.defense = 21;
			item.rare = ItemRarityID.Red;
			item.width = dims.Width;
			item.value = Item.sellPrice(0, 40, 0, 0);
			item.height = dims.Height;
		}

		public override void UpdateEquip(Player player)
		{
			ExxoAvalonOriginsModPlayer modPlayer = player.GetModPlayer<ExxoAvalonOriginsModPlayer>();
			modPlayer.teleportV = true;
			modPlayer.thornMagic = true;
		}
	}
}