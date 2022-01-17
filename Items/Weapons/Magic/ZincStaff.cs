using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Magic
{
	class ZincStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Zinc Staff");
            Item.staff[item.type] = true;
        }

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.SapphireStaff);
			Item.staff[item.type] = true;
            Rectangle dims = this.GetDims();
            item.autoReuse = true;
            item.width = dims.Width;
            item.height = dims.Height;
            item.damage = 21;
            item.shootSpeed = 7.5f;
            item.mana = 8;
            item.rare = ItemRarityID.Blue;
            item.useTime = 30;
            item.useAnimation = 30;
            item.knockBack = 4f;
            item.shoot = ProjectileID.EmeraldBolt;
            item.value = 20000;
            item.UseSound = SoundID.Item43;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Placeable.Bar.ZincBar>(), 10);
            recipe.AddIngredient(ItemID.Sapphire, 8);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Placeable.Bar.ZincBar>(), 10);
            recipe.AddIngredient(ItemID.Emerald, 8);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
