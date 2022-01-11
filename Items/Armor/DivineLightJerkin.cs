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
    [AutoloadEquip(EquipType.Body)]
    class DivineLightJerkin : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Divine Light Jerkin");
			Tooltip.SetDefault("10% increased critical strike chance" +
				"\n25% increased critical damage");
		}

		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/Armor/DivineLightJerkin");
			item.defense = 18;
			item.rare = ItemRarityID.LightRed;
			item.width = dims.Width;
			item.value = Item.sellPrice(0, 1, 90, 0);
			item.height = dims.Height;
		}
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PixieDust, 25);
            recipe.AddIngredient(ItemID.HallowedBar, 25);
            recipe.AddIngredient(ItemID.SoulofLight, 20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override void UpdateEquip(Player player)
		{
			player.magicCrit += 10;
			player.meleeCrit += 10;
			player.rangedCrit += 10;
			player.thrownCrit += 10;
			player.GetModPlayer<ExxoAvalonOriginsModPlayer>().critDamageMult += 0.25f;
		}
	}
}
