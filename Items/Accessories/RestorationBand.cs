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
			item.rare = ItemRarityID.Orange;
			item.width = dims.Width;
			item.accessory = true;
			item.value = Item.sellPrice(0, 1, 0, 0);
			item.height = dims.Height;
		}
        public override void AddRecipes()
        {
            ModRecipe r = new ModRecipe(mod);
            r.AddIngredient(ItemID.LifeCrystal);
            r.AddIngredient(ItemID.ManaCrystal);
            r.AddIngredient(ModContent.ItemType<Consumables.StaminaCrystal>());
            r.AddIngredient(ItemID.Shackle, 2);
            r.AddTile(TileID.TinkerersWorkbench);
            r.SetResult(this);
            r.AddRecipe();
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
		{
            player.lifeRegen++;
            player.manaRegen++;
            player.Avalon().staminaRegen = 1700;
        }
	}
}
