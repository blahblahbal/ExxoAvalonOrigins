using ExxoAvalonOrigins.Items.Ammo;
using ExxoAvalonOrigins.Items.Material;
using ExxoAvalonOrigins.Items.Placeable.Bar;
using ExxoAvalonOrigins.Items.Placeable.Tile;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Blah
{
    class BlahBullet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blah Bullet");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.shootSpeed = 11.5f;
            item.damage = 30;
            item.ammo = AmmoID.Bullet;
            item.ranged = true;
            item.consumable = true;
            item.rare = ItemRarityID.Purple;
            item.width = dims.Width;
            item.knockBack = 4f;
            item.shoot = ModContent.ProjectileType<Projectiles.BlahBullet>();
            item.maxStack = 2000;
            item.value = 200;
            item.height = dims.Height;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<BerserkerBullet>(), 75);
            recipe.AddIngredient(ModContent.ItemType<PyroscoricBullet>(), 75);
            recipe.AddIngredient(ModContent.ItemType<Electrobullet>(), 75);
            recipe.AddIngredient(ModContent.ItemType<Phantoplasm>(), 3);
            recipe.AddIngredient(ModContent.ItemType<SuperhardmodeBar>(), 2);
            recipe.AddIngredient(ModContent.ItemType<SoulofTorture>(), 3);
            recipe.AddTile(ModContent.TileType<Tiles.SolariumAnvil>());
            recipe.SetResult(this, 350);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<BerserkerBullet>(), 75);
            recipe.AddIngredient(ModContent.ItemType<TritonBullet>(), 75);
            recipe.AddIngredient(ModContent.ItemType<Electrobullet>(), 75);
            recipe.AddIngredient(ModContent.ItemType<Phantoplasm>(), 3);
            recipe.AddIngredient(ModContent.ItemType<SuperhardmodeBar>(), 2);
            recipe.AddIngredient(ModContent.ItemType<SoulofTorture>(), 3);
            recipe.AddTile(ModContent.TileType<Tiles.SolariumAnvil>());
            recipe.SetResult(this, 350);
            recipe.AddRecipe();
        }
    }
}
