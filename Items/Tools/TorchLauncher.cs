using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tools;

class TorchLauncher : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Torch Launcher");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.damage = 0;
        Item.UseSound = SoundID.Item5;
        Item.shootSpeed = 8f;
        Item.useAmmo = 8;
        Item.DamageType = DamageClass.Ranged;
        Item.noMelee = true;
        Item.rare = ItemRarityID.Green;
        Item.width = dims.Width;
        Item.useTime = 16;
        Item.knockBack = 0f;
        Item.shoot = ModContent.ProjectileType<Projectiles.Torches.Torch>();
        Item.value = 39000;
        Item.useStyle = ItemUseStyleID.Shoot;
        Item.useAnimation = 16;
        Item.height = dims.Height;
    }
    public override void AddRecipes()
    {
        CreateRecipe(1).AddIngredient(ItemID.Torch, 50).AddIngredient(ItemID.IronBar, 10).AddIngredient(ItemID.Wood, 20).AddTile(TileID.Anvils).Register();
    }
}