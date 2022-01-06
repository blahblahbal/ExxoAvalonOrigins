using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Other
{
	class Quack : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Quack");
			Tooltip.SetDefault("'May annoy others'");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.noUseGraphic = true;
			item.rare = ItemRarityID.Red;
            item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().avalonRarity = AvalonRarity.Rainbow;
            item.width = dims.Width;
			item.useTurn = true;
			item.useTime = 30;
			item.useStyle = 10;
			item.value = 100;
			item.useAnimation = 30;
			item.height = dims.Height;
		}

        public override bool UseItem(Player player)
        {
            Main.PlaySound(SoundID.Zombie, -1, -1, 12);
            return true;    
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            foreach (TooltipLine line in tooltips)
            {
                if (line.mod == "Terraria" && line.Name == "ItemName")
                {
                    line.overrideColor = new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB);
                }
            }
        }
    }
}
