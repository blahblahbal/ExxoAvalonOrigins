using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Potions
{
	class LuckPotion : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Luck Potion");
			Tooltip.SetDefault("Doubles rare drop chance");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.buffType = ModContent.BuffType<Buffs.Luck>();
			item.consumable = true;
			item.rare = ItemRarityID.Green;
			item.width = dims.Width;
			item.useTime = 15;
			item.useStyle = ItemUseStyleID.EatingUsing;
			item.maxStack = 100;
			item.useAnimation = 15;
			item.height = dims.Height;
			item.buffTime = 108000;
            item.UseSound = SoundID.Item3;
        }
	}
}
