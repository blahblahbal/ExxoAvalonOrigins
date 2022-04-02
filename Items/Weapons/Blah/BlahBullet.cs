using ExxoAvalonOrigins.Items.Ammo;
using ExxoAvalonOrigins.Items.Material;
using ExxoAvalonOrigins.Items.Placeable.Bar;
using ExxoAvalonOrigins.Items.Placeable.Tile;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Blah;

class BlahBullet : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Blah Bullet");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.shootSpeed = 11.5f;
        Item.damage = 30;
        Item.ammo = AmmoID.Bullet;
        Item.DamageType = DamageClass.Ranged;
        Item.consumable = true;
        Item.rare = ItemRarityID.Purple;
        Item.width = dims.Width;
        Item.knockBack = 4f;
        Item.shoot = ModContent.ProjectileType<Projectiles.BlahBullet>();
        Item.maxStack = 2000;
        Item.value = 200;
        Item.height = dims.Height;
    }
    public override void AddRecipes()
    {
        CreateRecipe(350).AddIngredient(ModContent.ItemType<BerserkerBullet>(), 75).AddIngredient(ModContent.ItemType<PyroscoricBullet>(), 75).AddIngredient(ModContent.ItemType<Electrobullet>(), 75).AddIngredient(ModContent.ItemType<Phantoplasm>(), 3).AddIngredient(ModContent.ItemType<SuperhardmodeBar>(), 2).AddIngredient(ModContent.ItemType<SoulofTorture>(), 3).AddTile(ModContent.TileType<Tiles.SolariumAnvil>()).Register();
        CreateRecipe(350).AddIngredient(ModContent.ItemType<BerserkerBullet>(), 75).AddIngredient(ModContent.ItemType<TritonBullet>(), 75).AddIngredient(ModContent.ItemType<Electrobullet>(), 75).AddIngredient(ModContent.ItemType<Phantoplasm>(), 3).AddIngredient(ModContent.ItemType<SuperhardmodeBar>(), 2).AddIngredient(ModContent.ItemType<SoulofTorture>(), 3).AddTile(ModContent.TileType<Tiles.SolariumAnvil>()).Register();
    }
}