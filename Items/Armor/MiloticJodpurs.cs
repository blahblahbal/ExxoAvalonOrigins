using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	class MiloticJodpurs : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Milotic Jodpurs");
			Tooltip.SetDefault("Increases your max number of minions by 1\n10% increased movement speed");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.defense = 28;
			item.rare = ItemRarityID.Red;
			item.width = dims.Width;
			item.value = Item.sellPrice(0, 40, 0, 0);
			item.height = dims.Height;
		}

		public override void UpdateEquip(Player player)
		{
			player.moveSpeed += 0.1f;
			player.maxMinions++;
		}
	}
}
