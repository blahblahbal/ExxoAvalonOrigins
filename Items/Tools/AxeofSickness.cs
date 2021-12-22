using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tools
{
	class AxeofSickness : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Axe of Sickness");
		}
		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.UseSound = SoundID.Item1;
			item.damage = 24;
			item.autoReuse = true;
			item.useTurn = true;
			item.scale = 1.2f;
			item.axe = 15;
			item.rare = ItemRarityID.Blue;
			item.width = dims.Width;
			item.useTime = 34;
			item.knockBack = 6f;
			item.melee = true;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.value = Item.sellPrice(0, 0, 36, 0);
			item.UseSound = SoundID.Item1;
			item.useAnimation = 34;
			item.height = dims.Height;
		}
    }
}
