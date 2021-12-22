using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Potions
{
	class SuperStaminaPotion : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Super Stamina Potion");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.consumable = true;
			item.rare = ItemRarityID.Yellow;
			item.width = dims.Width;
			item.useTurn = true;
			item.useTime = 17;
			item.useStyle = ItemUseStyleID.EatingUsing;
			item.maxStack = 99;
			item.value = 4000;
			item.useAnimation = 17;
			item.height = dims.Height;
            item.UseSound = SoundID.Item3;
        }
	}
}
