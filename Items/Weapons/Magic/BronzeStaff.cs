using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Magic
{
    class BronzeStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bronze Staff");
            Item.staff[item.type] = true;
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.SapphireStaff);
            Item.staff[item.type] = true;
            Rectangle dims = this.GetDims();
            item.width = dims.Width;
            item.height = dims.Height;
            item.damage = 17;
            item.shootSpeed = 7.5f;
            item.mana = 5;
            item.rare = ItemRarityID.Blue;
            item.useTime = 36;
            item.useAnimation = 36;
            item.knockBack = 4f;
            item.shoot = ProjectileID.AmethystBolt;
            item.value = 4000;
            item.UseSound = SoundID.Item43;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Placeable.Bar.BronzeBar>(), 10);
            recipe.AddIngredient(ItemID.Topaz, 8);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Placeable.Bar.BronzeBar>(), 10);
            recipe.AddIngredient(ItemID.Amethyst, 8);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
