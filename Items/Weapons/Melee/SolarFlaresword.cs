using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Melee
{
	class SolarFlaresword : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Solar Flaresword");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
            item.damage = 82;
			item.autoReuse = true;
			item.rare = ItemRarityID.Cyan;
			item.width = dims.Width;
			item.knockBack = 7f;
			item.useTime = 25;
			item.melee = true;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.value = Item.sellPrice(0, 9, 87, 65);
			item.useAnimation = 25;
			item.height = dims.Height;
            item.UseSound = SoundID.Item1;
        }
	}
}
