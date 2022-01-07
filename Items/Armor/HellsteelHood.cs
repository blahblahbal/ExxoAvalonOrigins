using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	class HellsteelHood : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hellsteel Hood");
			Tooltip.SetDefault("25% increased minion damage");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.defense = 27;
			item.rare = ItemRarityID.Cyan;
			item.width = dims.Width;
			item.value = Item.sellPrice(0, 10, 0, 0);
			item.height = dims.Height;
		}
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Material.HellsteelPlate>(), 6);
			recipe.AddIngredient(ModContent.ItemType<Armor.FleshCap>());
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<HellsteelVest>() && legs.type == ModContent.ItemType<HellsteelPants>();
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Increases your max number of minions by 5";
			player.maxMinions += 10;
		}

		public override void UpdateEquip(Player player)
		{
			player.minionDamage += 0.25f;
		}
	}
}
