using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories
{
	[AutoloadEquip(EquipType.Wings)]
	class CorruptionWings : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Corruption Wings");
			Tooltip.SetDefault("Allows flight and slow fall\nOther bonuses apply when in the Corruption");
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
            if (player.ZoneCorrupt)
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
            r.AddIngredient(ItemID.RottenChunk, 20);
            r.AddIngredient(ItemID.CursedFlame, 25);
            r.AddTile(TileID.MythrilAnvil);
            r.SetResult(this);
            r.AddRecipe();
        }
	}
}
