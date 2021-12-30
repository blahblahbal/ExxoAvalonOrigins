using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ExxoAvalonOrigins.Items.Armor
{
    [AutoloadEquip(EquipType.Legs)]
    class AvalonCuisses : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Avalon Cuisses");
			Tooltip.SetDefault("30% increased critical damage"
				+ "\n10% increased melee speed"
				+ "\nLightning strikes when damaged");
		}

		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/Armor/AvalonCuisses");
			item.defense = 38;
			item.rare = ItemRarityID.Yellow;
			item.width = dims.Width;
			item.value = Item.sellPrice(0, 41, 0, 0);
			item.height = dims.Height;
		}
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            foreach (TooltipLine line in tooltips)
            {
                if (line.mod == "Terraria" && line.Name == "ItemName")
                {
                    List<Color> colors = new List<Color>
                    {
                        new Color(71, 142, 147),
                        new Color(255, 242, 0)
                    };
                    int num = (int)(Main.GlobalTime / 2f % colors.Count);
                    Color teal = colors[num];
                    Color yellow = colors[(num + 1) % colors.Count];
                    line.overrideColor = Color.Lerp(teal, yellow, (Main.GlobalTime % 2f > 1f) ? 1f : (Main.GlobalTime % 1f));
                }
            }
        }
        public override void UpdateEquip(Player player)
		{
			player.moveSpeed += 0.15f;
			player.meleeSpeed += 0.10f;
			player.GetModPlayer<ExxoAvalonOriginsModPlayer>().LightningInABottle = true;
		}
	}
}
