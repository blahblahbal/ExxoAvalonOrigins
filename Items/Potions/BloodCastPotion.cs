using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Potions
{
	class BloodCastPotion : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blood Cast Potion");
			Tooltip.SetDefault("Adds your max life to your max mana");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.buffType = ModContent.BuffType<Buffs.BloodCast>();
			item.UseSound = SoundID.Item3;
			item.consumable = true;
			item.rare = ItemRarityID.Green;
			item.width = dims.Width;
			item.useTime = 15;
			item.useStyle = ItemUseStyleID.EatingUsing;
			item.maxStack = 100;
			item.value = Item.sellPrice(0, 0, 5, 0);
			item.useAnimation = 15;
			item.height = dims.Height;
			item.buffTime = 18000;
		}
	}
}
