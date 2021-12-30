using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	class BlahsCuisses2 : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blah's Cuisses");
			Tooltip.SetDefault("Melee weapons have a chance to instantly kill your non-boss enemies\nRanged projectiles have a chance to split in two\nTeleportation to the cursor is enabled");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.defense = 100;
			item.rare = ItemRarityID.Purple;
            item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().avalonRarity = AvalonRarity.Rainbow;
            item.width = dims.Width;
			item.value = Item.sellPrice(2, 0, 0, 0);
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
                        new Color(252, 66, 0),
                        new Color(203, 203, 203)
                    };
                    int num = (int)(Main.GlobalTime / 2f % colors.Count);
                    Color orange = colors[num];
                    Color silver = colors[(num + 1) % colors.Count];
                    line.overrideColor = Color.Lerp(orange, silver, (Main.GlobalTime % 2f > 1f) ? 1f : (Main.GlobalTime % 1f));
                }
            }
        }
        public override void UpdateEquip(Player player)
		{
			player.GetModPlayer<ExxoAvalonOriginsModPlayer>().oblivionKill = true;
			player.GetModPlayer<ExxoAvalonOriginsModPlayer>().splitProj = true;
			player.GetModPlayer<ExxoAvalonOriginsModPlayer>().teleportV = true;
		}
	}
}
