using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tools
{
	class NaquadahGreataxe : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Naquadah Greataxe");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.damage = 29;
			item.autoReuse = true;
			item.useTurn = true;
			item.scale = 1f;
			item.axe = 18;
			item.rare = ItemRarityID.LightRed;
			item.width = dims.Width;
			item.useTime = 18;
			item.knockBack = 7f;
			item.melee = true;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.value = Item.sellPrice(0, 1, 40, 0);
			item.useAnimation = 18;
			item.height = dims.Height;
            item.UseSound = SoundID.Item1;
        }
	}
}
