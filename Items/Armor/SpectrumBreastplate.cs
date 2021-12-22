using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	class SpectrumBreastplate : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spectrum Breastplate");
			Tooltip.SetDefault("Ranged projectiles have a chance to split in two");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.defense = 33;
			item.rare = ItemRarityID.Red;
			item.width = dims.Width;
			item.value = Item.sellPrice(0, 40, 0, 0);
			item.height = dims.Height;
		}

		public override void UpdateEquip(Player player)
		{
			player.GetModPlayer<ExxoAvalonOriginsModPlayer>().splitProj = true;
		}
	}
}
