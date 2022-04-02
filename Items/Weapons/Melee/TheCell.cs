using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Melee;

class TheCell : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("The Cell");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.UseSound = SoundID.Item1;
        Item.damage = 17;
        Item.noUseGraphic = true;
        Item.channel = true;
        Item.scale = 1f;
        Item.shootSpeed = 12f;
        Item.rare = ItemRarityID.Blue;
        Item.noMelee = true;
        Item.width = dims.Width;
        Item.useTime = 45;
        Item.knockBack = 6.5f;
        Item.shoot = ModContent.ProjectileType<Projectiles.Cell>();
        Item.DamageType = DamageClass.Melee;
        Item.useStyle = ItemUseStyleID.Shoot;
        Item.value = 27000;
        Item.useAnimation = 45;
        Item.height = dims.Height;
    }
    public override void AddRecipes()
    {
        CreateRecipe(1).AddIngredient(ModContent.ItemType<Placeable.Bar.BacciliteBar>(), 10).AddIngredient(ModContent.ItemType<Material.Booger>(), 2).AddTile(TileID.Anvils).Register();
    }
}