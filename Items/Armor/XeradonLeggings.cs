using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	class XeradonLeggings : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Xeradon Leggings");
			Tooltip.SetDefault("10% increased mining speed\n10% increased block placement speed");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.defense = 10;
			item.rare = ItemRarityID.Pink;
			item.width = dims.Width;
            item.value = Item.sellPrice(0, 2);
			item.height = dims.Height;
		}

		public override void UpdateEquip(Player player)
		{
            player.wallSpeed += 0.1f;
            player.tileSpeed += 0.1f;
            player.pickSpeed -= 0.1f;
        }
        public override void AddRecipes()
        {
            ModRecipe r = new ModRecipe(mod);
            r.AddIngredient(ItemID.MiningPants);
            r.AddIngredient(ItemID.AdamantiteBar, 3);
            r.AddIngredient(ItemID.TitaniumBar, 3);
            r.AddIngredient(ModContent.ItemType<Placeable.Bar.TroxiniumBar>(), 3);
            r.AddTile(TileID.MythrilAnvil);
            r.SetResult(this);
            r.AddRecipe();
        }
    }
}
