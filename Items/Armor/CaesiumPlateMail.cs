using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	class CaesiumPlateMail : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Caesium Plate Mail");
			Tooltip.SetDefault("5% increased melee critical strike chance\nMelee attacks inflict On Fire!");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.defense = 25;
			item.rare = ItemRarityID.Lime;
			item.width = dims.Width;
			item.value = Item.sellPrice(0, 9, 0, 0);
			item.height = dims.Height;
		}

		public override void UpdateEquip(Player player)
		{
			player.meleeCrit += 5;
			player.magmaStone = true;
		}
	}
}
