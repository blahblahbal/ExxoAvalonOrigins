using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Magic
{
	class GlassEye : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Glass Eye");
		}
		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.damage = 14;
			item.scale = 1.1f;
			item.magic = true;
			item.autoReuse = false;
			item.noMelee = true;
			item.useTurn = false;
			item.rare = ItemRarityID.Blue;
			item.width = dims.Width;
			item.height = dims.Height;
			item.useTime = 35;
			item.useAnimation = 35;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.knockBack = 2f;
			item.mana = 3;
			item.shoot = ModContent.ProjectileType<Projectiles.Tear>();
			item.shootSpeed = 12f;
			item.UseSound = SoundID.NPCHit1;
			item.value = Item.sellPrice(0, 1, 0, 0);
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Lens, 1);
			recipe.AddIngredient(ItemID.Glass, 5);
			recipe.AddIngredient(ItemID.FallenStar, 3);
			recipe.AddIngredient(ItemID.BottledWater, 1);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(5, 0);
		}
	}
}
