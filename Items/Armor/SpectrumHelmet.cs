using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	class SpectrumHelmet : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spectrum Helmet");
			Tooltip.SetDefault("20% increased ranged damage\n3% increased ranged critical strike chance");
		}
		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.defense = 32;
			item.rare = ItemRarityID.Red;
			item.width = dims.Width;
			item.value = Item.sellPrice(0, 40, 0, 0);
			item.height = dims.Height;
		}
		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<SpectrumBreastplate>() && legs.type == ModContent.ItemType<SpectrumGreaves>();
		}
		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "The slower you walk the more damage you gain, up to 25%" +
				"\nWhile moving at maximum speed, you have a chance to dodge attacks";
			player.GetModPlayer<ExxoAvalonOriginsModPlayer>().spectrumSpeed = true;
		}
		public override void UpdateEquip(Player player)
		{
			player.rangedDamage += 0.25f;
			player.rangedCrit += 3;
		}
	}
}
