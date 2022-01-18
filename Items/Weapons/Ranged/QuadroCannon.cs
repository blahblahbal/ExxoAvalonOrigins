using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Ranged
{
    class QuadroCannon : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Quadro Cannon");
            Tooltip.SetDefault("Four round burst\nOnly the first shot consumes ammo and fires a spread of bullets");
        }
        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.damage = 15;
            item.autoReuse = true;
            item.shootSpeed = 14f;
            item.useAmmo = AmmoID.Bullet;
            item.ranged = true;
            item.rare = ItemRarityID.Yellow;
            item.noMelee = true;
            item.width = dims.Width;
            item.useTime = 4;
            item.knockBack = 5f;
            item.shoot = ProjectileID.Bullet;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.value = 780000;
            item.reuseDelay = 14;
            item.useAnimation = 16;
            item.height = dims.Height;
            item.UseSound = SoundID.Item11;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ClockworkAssaultRifle);
            recipe.AddIngredient(ItemID.Shotgun);
            recipe.AddIngredient(ModContent.ItemType<Placeable.Tile.DragonScale>(), 10);
            recipe.AddIngredient(ItemID.SoulofFright);
            recipe.AddIngredient(ItemID.SoulofSight);
            recipe.AddIngredient(ItemID.SoulofMight);
            recipe.AddIngredient(ModContent.ItemType<Material.LensApparatus>());
            recipe.AddIngredient(ModContent.ItemType<Placeable.Tile.Onyx>(), 25);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-10, 0);
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            //sound is weird sometimes?? idk why tho
            for (int num209 = 0; num209 < 4; num209++)
            {
                float num210 = speedX;
                float num211 = speedY;
                num210 += (float)Main.rand.Next(-24, 25) * 0.05f;
                num211 += (float)Main.rand.Next(-24, 25) * 0.05f;
                Projectile.NewProjectile(position.X, position.Y, num210, num211, type, damage, knockBack, player.whoAmI, 0f, 0f);
                Main.PlaySound(SoundID.Item, -1, -1, 11);
            }
            return false;
        }
        public override bool ConsumeAmmo(Player player)
        {
            return player.itemAnimation >= item.useAnimation - 4;
        }
    }
}
