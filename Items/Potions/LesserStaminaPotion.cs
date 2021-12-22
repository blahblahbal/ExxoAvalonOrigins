using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Potions
{
	class LesserStaminaPotion : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lesser Stamina Potion");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.consumable = true;
			item.width = dims.Width;
			item.useTurn = true;
			item.useTime = 17;
			item.useStyle = ItemUseStyleID.EatingUsing;
			item.maxStack = 30;
			item.value = 400;
			item.useAnimation = 17;
			item.height = dims.Height;
            item.UseSound = SoundID.Item3;
        }
	}
}
