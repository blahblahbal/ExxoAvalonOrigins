using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories
{
	class RestorationBand : ModItem
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Restoration Band");
			Tooltip.SetDefault("Provides life, mana, and stamina regeneration");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			Item.rare = ItemRarityID.Orange;
			Item.width = dims.Width;
			Item.accessory = true;
			Item.value = Item.sellPrice(0, 1, 0, 0);
			Item.height = dims.Height;
		}
        public override void AddRecipes()
        {
            CreateRecipe(1).AddIngredient(ItemID.LifeCrystal).AddIngredient(ItemID.ManaCrystal).AddIngredient(ModContent.ItemType<Consumables.StaminaCrystal>()).AddIngredient(ItemID.Shackle, 2).AddTile(TileID.TinkerersWorkbench).Register();
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
		{
            player.lifeRegen++;
            player.manaRegen++;
            player.Avalon().staminaRegen = 1700;
        }
	}
}
