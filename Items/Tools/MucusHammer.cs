using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tools
{
	class MucusHammer : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mucus Hammer");
		}
		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.UseSound = SoundID.Item1;
			item.damage = 25;
			item.autoReuse = true;
			item.hammer = 55;
			item.useTurn = true;
			item.scale = 1.2f;
			item.rare = ItemRarityID.Blue;
			item.width = dims.Width;
			item.useTime = 35;
			item.knockBack = 6f;
			item.melee = true;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.value = Item.sellPrice(0, 0, 36, 0);
			item.useAnimation = 35;
			item.height = dims.Height;
            item.UseSound = SoundID.Item1;
        }
	}
}
