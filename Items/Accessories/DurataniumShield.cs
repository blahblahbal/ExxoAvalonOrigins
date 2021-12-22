using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories
{
	class DurataniumShield : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Duratanium Shield");
			Tooltip.SetDefault("Slows the effects of damage over time debuffs");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.defense = 2;
			item.rare = ItemRarityID.LightRed;
			item.width = dims.Width;
			item.value = 54000;
			item.accessory = true;
			item.height = dims.Height;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetModPlayer<ExxoAvalonOriginsModPlayer>().frontReflect = true;
		}
	}
}
