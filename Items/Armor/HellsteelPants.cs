using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	class HellsteelPants : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hellsteel Pants");
			Tooltip.SetDefault("Increases your max number of minions by 5");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.defense = 25;
			item.rare = ItemRarityID.Cyan;
			item.width = dims.Width;
			item.value = Item.sellPrice(0, 9, 0, 0);
			item.height = dims.Height;
		}
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Material.HellsteelPlate>(), 5);
			recipe.AddIngredient(ModContent.ItemType<Armor.FleshPants>());
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override void UpdateEquip(Player player)
		{
			player.maxMinions += 5;
		}
	}
}
