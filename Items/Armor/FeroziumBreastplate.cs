using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	class FeroziumBreastplate : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ferozium Breastplate");
			Tooltip.SetDefault("17% increased melee and ranged critical strike chance");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.defense = 23;
			item.rare = ItemRarityID.Yellow;
			item.width = dims.Width;
			item.value = 300000;
			item.height = dims.Height;
		}

		public override void UpdateEquip(Player player)
		{
			player.meleeCrit += 17;
			player.rangedCrit += 17;
		}
	}
}
