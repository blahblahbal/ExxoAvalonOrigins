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
            Item.damage = 131;
            Item.autoReuse = true;
            Item.useTurn = false;
            Item.useAmmo = AmmoID.Bullet;
            Item.shootSpeed = 13f;
            Item.crit += 4;
            Item.DamageType = DamageClass.Ranged;
            Item.rare = 11;
            Item.noMelee = true;
            Item.width = dims.Width;
            Item.knockBack = 3f;
            Item.useTime = 4;
            Item.shoot = ProjectileID.Bullet;
            Item.value = Item.sellPrice(1, 0, 0, 0);
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useAnimation = 4;
            Item.height = dims.Height;
            Item.UseSound = SoundID.Item41;

        }
        public override void AddRecipes()
        {
            CreateRecipe(1).AddIngredient(ModContent.ItemType<Phantoplasm>(), 45).AddIngredient(ModContent.ItemType<SuperhardmodeBar>(), 40).AddIngredient(ModContent.ItemType<SoulofTorture>(), 45).AddIngredient(ModContent.ItemType<PlanterasFury>()).AddIngredient(ItemID.ChainGun).AddIngredient(ItemID.Megashark).AddTile(ModContent.TileType<Tiles.SolariumAnvil>()).Register();
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
            if (player.inventory[player.selectedItem].type == Item.type)
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
