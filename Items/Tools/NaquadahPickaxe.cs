using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tools
{
	class NaquadahPickaxe : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Naquadah Pickaxe");
			Tooltip.SetDefault("Can mine Adamantite, Titanium, and Troxinium");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.damage = 12;
			item.autoReuse = true;
			item.useTurn = true;
			item.scale = 1f;
			item.pick = 150;
			item.rare = ItemRarityID.LightRed;
			item.width = dims.Width;
			item.useTime = 20;
			item.knockBack = 1f;
			item.melee = true;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.value = Item.sellPrice(0, 1, 40, 0);
			item.useAnimation = 20;
			item.height = dims.Height;
            item.UseSound = SoundID.Item1;
        }
	}
}
