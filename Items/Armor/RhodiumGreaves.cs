using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	class RhodiumGreaves : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Rhodium Greaves");
			Tooltip.SetDefault("10% increased magic damage");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.defense = 7;
			item.rare = ItemRarityID.Orange;
			item.width = dims.Width;
			item.value = Item.sellPrice(0, 1, 0, 0);
			item.height = dims.Height;
		}
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Placeable.Bar.RhodiumBar>(), 17);
            recipe.AddIngredient(ModContent.ItemType<Material.DesertFeather>(), 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override void UpdateEquip(Player player)
		{
			player.magicDamage += 0.1f;
		}
	}
}
