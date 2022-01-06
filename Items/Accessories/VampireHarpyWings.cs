using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories
{
	[AutoloadEquip(EquipType.Wings)]
	class VampireHarpyWings : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Vampire Harpy Wings");
			Tooltip.SetDefault("Allows flight and slow fall and heals life\nOther bonuses apply when in the Dark Matter");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.rare = ItemRarityID.Red;
            item.width = dims.Width;
			item.value = 800000;
			item.accessory = true;
			item.height = dims.Height;
		}

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.wingTimeMax = 210;
            if (player.GetModPlayer<ExxoAvalonOriginsModPlayer>().zoneDarkMatter)
            {
                player.statDefense += 8;
                player.lifeRegen += 5;
            }
        }
	}
}
