using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Ranged
{
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
            item.damage = 98;
            item.autoReuse = true;
            item.useTurn = false;
            item.useAmmo = AmmoID.Rocket;
            item.shootSpeed = 10f;
            item.crit += 3;
            item.ranged = true;
            item.rare = ItemRarityID.Red;
            item.noMelee = true;
            item.width = dims.Width;
            item.knockBack = 5f;
            item.useTime = 15;
            item.shoot = ProjectileID.RocketI;
            item.value = Item.sellPrice(1, 0, 0, 0);
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useAnimation = 15;
            item.height = dims.Height;
            item.UseSound = SoundID.Item11;

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
}
