using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Potions
{
	class BlahPotion : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blah Potion");
			Tooltip.SetDefault("Various effects");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.buffType = ModContent.BuffType<Buffs.Blah>();
			item.UseSound = SoundID.Item3;
			item.consumable = false;
			item.rare = ItemRarityID.Purple;
            //item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().avalonRarity = AvalonRarity.Rainbow;
            item.width = dims.Width;
			item.useTime = 15;
			item.useStyle = ItemUseStyleID.EatingUsing;
			item.maxStack = 1;
			item.useAnimation = 15;
			item.height = dims.Height;
			item.buffTime = 1080000;
		}
    }
}
