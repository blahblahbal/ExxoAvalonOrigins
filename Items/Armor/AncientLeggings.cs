using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	class AncientLeggings : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ancient Leggings");
			Tooltip.SetDefault("Increases your max number of minions by 3\nIncreases maximum mana by 80");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.defense = 25;
			item.rare = ItemRarityID.Cyan;
			item.width = dims.Width;
			item.value = Item.sellPrice(0, 30, 0, 0);
			item.height = dims.Height;
		}
        public override void AddRecipes()
        {
            ModRecipe r = new ModRecipe(mod);
            r.AddIngredient(ItemID.SolarFlareLeggings);
            r.AddIngredient(ItemID.FragmentNebula, 10);
            r.AddIngredient(ItemID.FragmentStardust, 10);
            r.AddIngredient(ItemID.FragmentVortex, 10);
            r.AddIngredient(ModContent.ItemType<Material.LifeDew>(), 5);
            r.AddIngredient(ModContent.ItemType<Material.GhostintheMachine>());
            r.AddTile(ModContent.TileType<Tiles.CaesiumForge>());
            r.SetResult(this);
            r.AddRecipe();

            r = new ModRecipe(mod);
            r.AddIngredient(ItemID.NebulaLeggings);
            r.AddIngredient(ItemID.FragmentSolar, 10);
            r.AddIngredient(ItemID.FragmentStardust, 10);
            r.AddIngredient(ItemID.FragmentVortex, 10);
            r.AddIngredient(ModContent.ItemType<Material.LifeDew>(), 5);
            r.AddIngredient(ModContent.ItemType<Material.GhostintheMachine>());
            r.AddTile(ModContent.TileType<Tiles.CaesiumForge>());
            r.SetResult(this);
            r.AddRecipe();

            r = new ModRecipe(mod);
            r.AddIngredient(ItemID.StardustLeggings);
            r.AddIngredient(ItemID.FragmentNebula, 10);
            r.AddIngredient(ItemID.FragmentSolar, 10);
            r.AddIngredient(ItemID.FragmentVortex, 10);
            r.AddIngredient(ModContent.ItemType<Material.LifeDew>(), 5);
            r.AddIngredient(ModContent.ItemType<Material.GhostintheMachine>());
            r.AddTile(ModContent.TileType<Tiles.CaesiumForge>());
            r.SetResult(this);
            r.AddRecipe();

            r = new ModRecipe(mod);
            r.AddIngredient(ItemID.VortexLeggings);
            r.AddIngredient(ItemID.FragmentNebula, 10);
            r.AddIngredient(ItemID.FragmentStardust, 10);
            r.AddIngredient(ItemID.FragmentSolar, 10);
            r.AddIngredient(ModContent.ItemType<Material.LifeDew>(), 5);
            r.AddIngredient(ModContent.ItemType<Material.GhostintheMachine>());
            r.AddTile(ModContent.TileType<Tiles.CaesiumForge>());
            r.SetResult(this);
            r.AddRecipe();


            //ModRecipe recipe = new ModRecipe(mod);
            //recipe.AddIngredient(ItemID.TurtleLeggings);
            //recipe.AddIngredient(ItemID.SpectrePants);
            //recipe.AddIngredient(ItemID.ShroomiteLeggings);
            //recipe.AddIngredient(ItemID.TikiPants);
            //recipe.AddIngredient(ModContent.ItemType<Material.LifeDew>(), 5);
            //recipe.AddTile(TileID.MythrilAnvil);
            //recipe.SetResult(ModContent.ItemType<AncientLeggings>());
            //recipe.AddRecipe();

            //recipe = new ModRecipe(mod);
            //recipe.AddIngredient(ItemID.TurtleLeggings);
            //recipe.AddIngredient(ItemID.SpectrePants);
            //recipe.AddIngredient(ItemID.ShroomiteLeggings);
            //recipe.AddIngredient(ItemID.SpookyLeggings);
            //recipe.AddIngredient(ModContent.ItemType<Material.LifeDew>(), 5);
            //recipe.AddTile(TileID.MythrilAnvil);
            //recipe.SetResult(ModContent.ItemType<AncientLeggings>());
            //recipe.AddRecipe();
        }
        public override void UpdateEquip(Player player)
		{
			player.maxMinions += 3;
			player.statManaMax2 += 80;
		}
	}
}
