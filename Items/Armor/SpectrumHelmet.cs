using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	class SpectrumHelmet : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spectrum Helmet");
			Tooltip.SetDefault("20% increased ranged damage\n3% increased ranged critical strike chance");
		}
		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.defense = 32;
			item.rare = ItemRarityID.Red;
			item.width = dims.Width;
			item.value = Item.sellPrice(0, 40, 0, 0);
			item.height = dims.Height;
		}
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Placeable.Bar.OblivionBar>(), 20);
            recipe.AddIngredient(ModContent.ItemType<Material.DarkMatterGel>(), 40);
            recipe.AddIngredient(ModContent.ItemType<AncientHeadpiece>());
            recipe.AddIngredient(ModContent.ItemType<Material.SoulofBlight>(), 3);
            recipe.AddIngredient(ModContent.ItemType<Placeable.Tile.Opal>(), 10);
            recipe.AddTile(ModContent.TileType<Tiles.SolariumAnvil>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<SpectrumBreastplate>() && legs.type == ModContent.ItemType<SpectrumGreaves>();
		}
		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "The slower you walk the more damage you gain, up to 25%" +
				"\nWhile moving at maximum speed, you have a chance to dodge attacks";
			player.GetModPlayer<ExxoAvalonOriginsModPlayer>().spectrumSpeed = true;
		}
		public override void UpdateEquip(Player player)
		{
			player.rangedDamage += 0.25f;
			player.rangedCrit += 3;
		}
	}
}
