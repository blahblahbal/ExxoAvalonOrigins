using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tools
{
	class BlahsPicksawTierII : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blah's Picksaw (Tier II)");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.damage = 55;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
			item.scale = 1.15f;
			item.axe = 60;
			item.pick = 700;
			item.rare = 11;
            item.width = dims.Width;
			item.useTime = 6;
			item.knockBack = 5.5f;
			item.melee = true;
			item.tileBoost += 8;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.value = 5016000;
			item.useAnimation = 6;
			item.height = dims.Height;
		}
        public override void HoldItem(Player player)
        {
            if (player.inventory[player.selectedItem].type == item.type)
            {
                player.pickSpeed -= 0.75f;
            }
        }
    }
}
