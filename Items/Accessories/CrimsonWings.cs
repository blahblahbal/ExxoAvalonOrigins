using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories
{
	[AutoloadEquip(EquipType.Wings)]
	class CrimsonWings : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crimson Flaps");
			Tooltip.SetDefault("Allows flight and slow fall\nOther bonuses apply when in the Crimson");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.rare = ItemRarityID.Yellow;
            item.width = dims.Width;
			item.value = 400000;
			item.accessory = true;
			item.height = dims.Height;
		}

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (player.ZoneCrimson)
            {
                player.statDefense += 5;
                player.statLifeMax2 += 40;
            }
            player.wingTimeMax = 140;
        }
        public override void AddRecipes()
        {
            ModRecipe r = new ModRecipe(mod);
            r.AddIngredient(ItemID.DemonWings);
            r.AddIngredient(ItemID.Vertebrae, 20);
            r.AddIngredient(ItemID.Ichor, 25);
            r.AddTile(TileID.MythrilAnvil);
            r.SetResult(this);
            r.AddRecipe();
        }
	}
}
