using System;
using ExxoAvalonOrigins.Items.Material;
using ExxoAvalonOrigins.Items.Placeable.Bar;
using ExxoAvalonOrigins.Items.Placeable.Tile;
using ExxoAvalonOrigins.Items.Weapons.Ranged;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Blah
{
    class SpraynBlah : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spray 'n' Blah");
            Tooltip.SetDefault("Fires very inaccurately\n30% chance to not consume ammo\n'Spray 'n' Pray'");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.damage = 131;
            item.autoReuse = true;
            item.useTurn = false;
            item.useAmmo = AmmoID.Bullet;
            item.shootSpeed = 13f;
            item.crit += 4;
            item.ranged = true;
            item.rare = 11;
            item.noMelee = true;
            item.width = dims.Width;
            item.knockBack = 3f;
            item.useTime = 4;
            item.shoot = ProjectileID.Bullet;
            item.value = Item.sellPrice(1, 0, 0, 0);
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useAnimation = 4;
            item.height = dims.Height;
            item.UseSound = SoundID.Item41;

        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Phantoplasm>(), 45);
            recipe.AddIngredient(ModContent.ItemType<SuperhardmodeBar>(), 40);
            recipe.AddIngredient(ModContent.ItemType<SoulofTorture>(), 45);
            recipe.AddIngredient(ModContent.ItemType<PlanterasFury>());
            recipe.AddIngredient(ItemID.ChainGun);
            recipe.AddIngredient(ItemID.Megashark);
            recipe.AddTile(ModContent.TileType<Tiles.SolariumAnvil>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-10f, 0f);
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage,
            ref float knockBack)
        {
            float num78 = speedX + (float)Main.rand.Next(-100, 101) * 0.05f;
            float num79 = speedY + (float)Main.rand.Next(-100, 101) * 0.05f;
            Projectile.NewProjectile(position.X, position.Y, num78, num79, type, damage, knockBack, player.whoAmI, 0f, 0f);
            return false;
        }
        public override void HoldItem(Player player)
        {
            Vector2 vector = new Vector2(player.position.X + player.width * 0.5f, player.position.Y + player.height * 0.5f);
            float num70 = Main.mouseX + Main.screenPosition.X - vector.X;
            float num71 = Main.mouseY + Main.screenPosition.Y - vector.Y;
            if (player.gravDir == -1f)
            {
                num71 = Main.screenPosition.Y + Main.screenHeight - Main.mouseY - vector.Y;
            }
            float num72 = (float)Math.Sqrt(num70 * num70 + num71 * num71);
            float num73 = num72;
            num72 = player.inventory[player.selectedItem].shootSpeed / num72;
            if (player.inventory[player.selectedItem].type == item.type)
            {
                num70 += Main.rand.Next(-100, 101) * 0.03f / num72;
                num71 += Main.rand.Next(-100, 101) * 0.03f / num72;
            }
            num70 *= num72;
            num71 *= num72;
            player.itemRotation = (float)Math.Atan2(num71 * player.direction, num70 * player.direction);
        }
        public override bool ConsumeAmmo(Player player)
        {
            if (Main.rand.Next(10) < 3) return false;
            return base.ConsumeAmmo(player);
        }
    }
}
