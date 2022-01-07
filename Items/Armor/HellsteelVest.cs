using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	class HellsteelVest : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hellsteel Vest");
			Tooltip.SetDefault("15% increased minion knockback\n20% increased movement speed");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.defense = 30;
			item.rare = ItemRarityID.Cyan;
			item.width = dims.Width;
			item.value = Item.sellPrice(0, 12, 0, 0);
			item.height = dims.Height;
		}
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Material.HellsteelPlate>(), 8);
			recipe.AddIngredient(ModContent.ItemType<Armor.FleshWrappings>());
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override void UpdateEquip(Player player)
		{
			player.minionKB += 0.15f;
			player.moveSpeed += 0.2f;
		}
	}
}
