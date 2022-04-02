using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Ranged;

class HeatSeeker : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Heat Seeker");
        Tooltip.SetDefault("Rockets turn into heat-seeking missiles");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.damage = 98;
        Item.autoReuse = true;
        Item.useTurn = false;
        Item.useAmmo = AmmoID.Rocket;
        Item.shootSpeed = 10f;
        Item.crit += 3;
        Item.DamageType = DamageClass.Ranged;
        Item.rare = ItemRarityID.Red;
        Item.noMelee = true;
        Item.width = dims.Width;
        Item.knockBack = 5f;
        Item.useTime = 15;
        Item.shoot = ProjectileID.RocketI;
        Item.value = Item.sellPrice(1, 0, 0, 0);
        Item.useStyle = ItemUseStyleID.Shoot;
        Item.useAnimation = 15;
        Item.height = dims.Height;
        Item.UseSound = SoundID.Item11;

    }
    //public override void AddRecipes()
    //{
    //    ModRecipe recipe = new ModRecipe(mod);
    //    recipe.AddIngredient(ModContent.ItemType<Phantoplasm>(), 45);
    //    recipe.AddIngredient(ModContent.ItemType<SuperhardmodeBar>(), 40);
    //    recipe.AddIngredient(ModContent.ItemType<SoulofTorture>(), 45);
    //    recipe.AddIngredient(ModContent.ItemType<TacticalExpulsor>());
    //    recipe.AddIngredient(ItemID.RocketLauncher);
    //    recipe.AddIngredient(ItemID.GrenadeLauncher);
    //    recipe.AddIngredient(ItemID.Stynger);
    //    recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
    //    recipe.SetResult(this);
    //    recipe.AddRecipe();
    //}
    public override Vector2? HoldoutOffset()
    {
        return new Vector2(-10f, 0f);
    }
    public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage,
                               ref float knockBack)
    {
        Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ModContent.ProjectileType<Projectiles.HomingRocketFriendly>(), damage, knockBack, player.whoAmI, 0f, 0f);
        return false;
    }
}