using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Ammo;

class UltrabrightRazorbladeBullet : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Ultrabright Razorblade Bullet");
        Tooltip.SetDefault("'Randomizer be like'");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.shootSpeed = 10f;
        Item.damage = 20;
        Item.ammo = AmmoID.Bullet;
        Item.DamageType = DamageClass.Ranged;
        Item.consumable = true;
        Item.width = dims.Width;
        Item.knockBack = 3.5f;
        Item.rare = ItemRarityID.Cyan;
        Item.shoot = ModContent.ProjectileType<Projectiles.UltrabrightRazorbladeBullet>();
        Item.maxStack = 2000;
        Item.value = Item.sellPrice(0, 0, 2);
        Item.height = dims.Height;
    }

    public override void AddRecipes()
    {
        CreateRecipe(250).AddIngredient(ItemID.MusketBall, 250).AddIngredient(ItemID.UltrabrightTorch, 250).AddIngredient(ItemID.RazorbladeTyphoon).AddTile(TileID.MythrilAnvil).Register();
    }
}