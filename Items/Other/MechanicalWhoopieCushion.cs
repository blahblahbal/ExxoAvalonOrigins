using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Other
{
	class MechanicalWhoopieCushion : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mechanical Whoopie Cushion");
			Tooltip.SetDefault("'Contains mechanical farts only'");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.noUseGraphic = true;
			item.rare = ItemRarityID.Cyan;
            item.width = dims.Width;
			item.useTurn = true;
			item.useTime = 30;
			item.useStyle = 10;
			item.value = 69;
			item.useAnimation = 30;
			item.height = dims.Height;
		}

        public override bool UseItem(Player player)
        {
            Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/MechanicalFart"));
            return true;    
        }
    }
}
