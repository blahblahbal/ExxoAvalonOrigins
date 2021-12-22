using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Melee
{
	class DurataniumWaraxe : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Duratanium Waraxe");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.damage = 25;
			item.autoReuse = true;
			item.useTurn = true;
			item.scale = 1f;
			item.axe = 15;
			item.rare = ItemRarityID.LightRed;
			item.width = dims.Width;
			item.useTime = 18;
			item.knockBack = 4f;
			item.melee = true;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.value = Item.sellPrice(0, 1, 0, 0);
			item.useAnimation = 18;
			item.height = dims.Height;
            item.UseSound = SoundID.Item1;
        }
	}
}
