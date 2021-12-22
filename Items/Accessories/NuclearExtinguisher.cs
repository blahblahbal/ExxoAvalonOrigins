using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories
{
	class NuclearExtinguisher : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nuclear Extinguisher");
			Tooltip.SetDefault("Immunity to Blackout and Cursed Inferno");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.rare = ItemRarityID.Yellow;
			item.width = dims.Width;
			item.accessory = true;
			item.value = 200000;
			item.height = dims.Height;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
				player.buffImmune[BuffID.Blackout] = true;
				player.buffImmune[BuffID.CursedInferno] = true;
		}
	}
}
