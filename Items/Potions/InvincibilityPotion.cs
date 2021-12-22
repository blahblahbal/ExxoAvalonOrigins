using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Potions
{
	class InvincibilityPotion : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Invincibility Potion");
			Tooltip.SetDefault("Grants invincibility");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			//item.buffType = ModContent.BuffType<Buffs.Invincibility>();
			item.consumable = true;
			item.rare = ItemRarityID.Green;
			item.width = dims.Width;
			item.useTime = 15;
			item.useStyle = ItemUseStyleID.EatingUsing;
			item.maxStack = 100;
			item.useAnimation = 15;
			item.height = dims.Height;
			item.buffTime = 600;
            item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().invince = true;
            item.UseSound = SoundID.Item3;
        }
	}
}
