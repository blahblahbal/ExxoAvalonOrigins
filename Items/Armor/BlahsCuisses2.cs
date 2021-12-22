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
                    line.overrideColor = new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB);
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
