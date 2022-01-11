using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tools
{
	class FeroziumWaraxe : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ferozium Waraxe");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.damage = 30;
			item.autoReuse = true;
			item.useTurn = true;
			item.scale = 1.5f;
			item.axe = 24;
			item.crit += 2;
			item.rare = ItemRarityID.Lime;
			item.width = dims.Width;
			item.useTime = 20;
			item.knockBack = 8f;
			item.melee = true;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.value = 350000;
			item.useAnimation = 20;
			item.height = dims.Height;
            item.UseSound = SoundID.Item1;
        }
	}
}
