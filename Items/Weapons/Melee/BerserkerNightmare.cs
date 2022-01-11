using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Melee
{
	class BerserkerNightmare : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Berserker Nightmare");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.noUseGraphic = true;
			item.damage = 84;
			item.autoReuse = true;
			item.channel = true;
			item.scale = 1.1f;
			item.shootSpeed = 10f;
			item.noMelee = true;
			item.rare = ItemRarityID.Cyan;
			item.width = dims.Width;
			item.useTime = 38;
			item.knockBack = 10f;
			item.shoot = ModContent.ProjectileType<Projectiles.BerserkerSphere>();
			item.UseSound = SoundID.Item1;
			item.melee = true;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.value = Item.sellPrice(0, 50, 0, 0);
			item.useAnimation = 38;
			item.height = dims.Height;
		}

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Placeable.Bar.BerserkerBar>(), 60);
            recipe.AddIngredient(ModContent.ItemType<Material.SoulofTorture>(), 75);
            recipe.AddIngredient(ModContent.ItemType<Material.ElementShard>(), 7);
            recipe.AddIngredient(ModContent.ItemType<Material.VictoryPiece>());
            recipe.AddIngredient(ItemID.Flairon);
            recipe.AddTile(ModContent.TileType<Tiles.SolariumAnvil>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
