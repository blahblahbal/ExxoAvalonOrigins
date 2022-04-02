using System;
using ExxoAvalonOrigins.Items.Material;
using ExxoAvalonOrigins.Items.Placeable.Bar;
using ExxoAvalonOrigins.Items.Placeable.Tile;
using ExxoAvalonOrigins.Items.Weapons.Ranged;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Blah;

class TacticalBlahncher : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Tactical Blahncher");
        Tooltip.SetDefault("Launches homing blahckets\n75% chance to not consume ammo");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.damage = 160;
        Item.autoReuse = true;
        Item.useTurn = false;
        Item.useAmmo = AmmoID.Rocket;
        Item.shootSpeed = 11f;
        Item.crit += 7;
        Item.DamageType = DamageClass.Ranged;
        Item.rare = 11;
        Item.noMelee = true;
        Item.width = dims.Width;
        Item.knockBack = 5f;
        Item.useTime = 9;
        Item.shoot = ProjectileID.RocketI;
        Item.value = Item.sellPrice(1, 0, 0, 0);
        Item.useStyle = ItemUseStyleID.Shoot;
        Item.useAnimation = 9;
        Item.height = dims.Height;
        Item.UseSound = SoundID.Item11;

    }
    public override void AddRecipes()
    {
        CreateRecipe(1).AddIngredient(ModContent.ItemType<Phantoplasm>(), 45).AddIngredient(ModContent.ItemType<SuperhardmodeBar>(), 40).AddIngredient(ModContent.ItemType<SoulofTorture>(), 45).AddIngredient(ModContent.ItemType<TacticalExpulsor>()).AddIngredient(ItemID.RocketLauncher).AddIngredient(ItemID.GrenadeLauncher).AddIngredient(ItemID.Stynger).AddTile(ModContent.TileType<Tiles.SolariumAnvil>()).Register();
    }
    public override Vector2? HoldoutOffset()
    {
        return new Vector2(-10f, 0f);
    }
    public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage,
                               ref float knockBack)
    {
        for (int i = 0; i < 3; i++)
        {
            float num78 = speedX + (float)Main.rand.Next(-50, 51) * 0.05f;
            float num79 = speedY + (float)Main.rand.Next(-50, 51) * 0.05f;
            if (Main.rand.Next(3) == 0)
            {
                num78 *= 1f + (float)Main.rand.Next(-40, 41) * 0.02f;
                num79 *= 1f + (float)Main.rand.Next(-40, 41) * 0.02f;
            }
            Projectile.NewProjectile(position.X, position.Y, num78, num79, ModContent.ProjectileType<Projectiles.Blahcket>(), damage, knockBack, player.whoAmI, 0f, 0f);
        }
        return false;
    }
    public override void HoldItem(Player player)
    {
        Vector2 vector = new Vector2(player.position.X + (float)player.width * 0.5f, player.position.Y + (float)player.height * 0.5f);
        float num70 = (float)Main.mouseX + Main.screenPosition.X - vector.X;
        float num71 = (float)Main.mouseY + Main.screenPosition.Y - vector.Y;
        if (player.gravDir == -1f)
        {
            num71 = Main.screenPosition.Y + (float)Main.screenHeight - (float)Main.mouseY - vector.Y;
        }
        float num72 = (float)Math.Sqrt((double)(num70 * num70 + num71 * num71));
        float num73 = num72;
        num72 = player.inventory[player.selectedItem].shootSpeed / num72;
        if (player.inventory[player.selectedItem].type == Item.type)
        {
            num70 += (float)Main.rand.Next(-50, 51) * 0.03f / num72;
            num71 += (float)Main.rand.Next(-50, 51) * 0.03f / num72;
        }
        num70 *= num72;
        num71 *= num72;
        player.itemRotation = (float)Math.Atan2((double)(num71 * (float)player.direction), (double)(num70 * (float)player.direction));
    }
    public override bool ConsumeAmmo(Player player)
    {
        if (Main.rand.Next(4) < 3) return false;
        return base.ConsumeAmmo(player);
    }
}