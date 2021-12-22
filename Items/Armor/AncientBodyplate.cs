using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	class AncientBodyplate : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ancient Bodyplate");
			Tooltip.SetDefault("Enemies are more likely to target you\nMinion knockback is increased by 10%");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.defense = 35;
			item.rare = ItemRarityID.Cyan;
			item.width = dims.Width;
			item.value = Item.sellPrice(0, 40, 0, 0);
			item.height = dims.Height;
		}

		public override void UpdateEquip(Player player)
		{
			player.aggro += 500;
			player.minionKB += 0.1f;
		}
	}
}
