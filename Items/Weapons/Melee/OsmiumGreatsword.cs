using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Melee
{
	class OsmiumGreatsword : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Osmium Greatsword");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.damage = 28;
			item.autoReuse = true;
			item.useTurn = true;
			item.scale = 1.5f;
			item.crit += 5;
			item.rare = ItemRarityID.Orange;
			item.width = dims.Width;
			item.useTime = 20;
			item.knockBack = 5f;
			item.melee = true;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.value = 50000;
			item.useAnimation = 20;
			item.height = dims.Height;
            item.UseSound = SoundID.Item1;
		}
	}
}
