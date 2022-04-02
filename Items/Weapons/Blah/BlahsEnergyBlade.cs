using ExxoAvalonOrigins.Items.Material;
using ExxoAvalonOrigins.Items.Placeable.Bar;
using ExxoAvalonOrigins.Items.Placeable.Tile;
using ExxoAvalonOrigins.Items.Weapons.Melee;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Blah;

class BlahsEnergyBlade : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Blah's Energy Blade");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.damage = 250;
        Item.autoReuse = true;
        Item.useTurn = true;
        Item.scale = 1.2f;
        Item.shootSpeed = 13f;
        Item.rare = 11;
        Item.width = dims.Width;
        Item.useTime = 14;
        Item.knockBack = 20f;
        Item.shoot = ModContent.ProjectileType<Projectiles.Melee.BlahBeam>();
        Item.UseSound = SoundID.Item1;
        Item.DamageType = DamageClass.Melee;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.value = Item.sellPrice(3, 0, 0, 0);
        Item.useAnimation = 14;
        Item.height = dims.Height;
    }
    public override Color? GetAlpha(Color lightColor)
    {
        return new Color(255, 255, 255, 255);
    }
    public override void AddRecipes()
    {
        CreateRecipe(1).AddIngredient(ModContent.ItemType<Phantoplasm>(), 45).AddIngredient(ModContent.ItemType<SuperhardmodeBar>(), 40).AddIngredient(ModContent.ItemType<SoulofTorture>(), 45).AddIngredient(ModContent.ItemType<ElementalExcalibur>()).AddIngredient(ModContent.ItemType<BerserkerBlade>()).AddIngredient(ModContent.ItemType<PumpkingsSword>()).AddTile(ModContent.TileType<Tiles.SolariumAnvil>()).Register();
    }
    public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage,
                               ref float knockBack)
    {
        for (int num194 = 0; num194 < 3; num194++)
        {
            float num195 = speedX;
            float num196 = speedY;
            num195 += (float)Main.rand.Next(-40, 41) * 0.05f;
            num196 += (float)Main.rand.Next(-40, 41) * 0.05f;
            Projectile.NewProjectile(position.X, position.Y, num195, num196, type, damage, knockBack, player.whoAmI, 0f, 0f);
        }

        return false;
    }
}