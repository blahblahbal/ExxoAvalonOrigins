using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Potions
{
	class StaminaPotion : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Stamina Potion");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.consumable = true;
			item.rare = ItemRarityID.Green;
			item.width = dims.Width;
			item.useTurn = true;
			item.useTime = 17;
			item.useStyle = ItemUseStyleID.EatingUsing;
			item.maxStack = 50;
			item.value = 900;
			item.useAnimation = 17;
			item.height = dims.Height;
            item.UseSound = SoundID.Item3;
        }
	}
}
