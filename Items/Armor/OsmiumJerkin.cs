using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	class OsmiumJerkin : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Osmium Jerkin");
			Tooltip.SetDefault("15% increased melee damage and speed");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.defense = 8;
			item.rare = ItemRarityID.Orange;
			item.width = dims.Width;
			item.value = Item.sellPrice(0, 1, 20, 0);
			item.height = dims.Height;
		}

		public override void UpdateEquip(Player player)
		{
			player.meleeDamage += 0.15f;
			player.meleeSpeed += 0.15f;
		}
	}
}
