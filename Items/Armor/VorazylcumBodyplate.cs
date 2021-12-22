using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	class VorazylcumBodyplate : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Vorazylcum Bodyplate");
			Tooltip.SetDefault("Enemies are a lot more likely to target you\nMinion knockback is increased by 10%");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.defense = 34;
			item.rare = ItemRarityID.Cyan;
			item.width = dims.Width;
			item.value = Item.sellPrice(0, 40, 0, 0);
			item.height = dims.Height;
		}

		public override void UpdateEquip(Player player)
		{
			player.aggro += 1500;
			player.minionKB += 0.1f;
		}
	}
}
