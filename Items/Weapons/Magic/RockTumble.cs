using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Magic;

class RockTumble : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Rock Tumble");
        Tooltip.SetDefault("Casts boulders");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.damage = 78;
        Item.autoReuse = true;
        Item.useTurn = true;
        Item.scale = 1;
        Item.shootSpeed = 8f;
        Item.rare = ItemRarityID.Yellow;
        Item.width = dims.Width;
        Item.useTime = 30;
        Item.knockBack = 5f;
        Item.noMelee = true;
        Item.mana = 25;
        Item.crit += 3;
        Item.shoot = ModContent.ProjectileType<Projectiles.Rock>();
        Item.UseSound = SoundID.Item20;
        Item.DamageType = DamageClass.Magic;
        Item.useStyle = ItemUseStyleID.Shoot;
        Item.value = Item.sellPrice(0, 10, 0, 0);
        Item.useAnimation = 30;
        Item.height = dims.Height;
    }
    //public override void AddRecipes()
    //{
    //    ModRecipe recipe = new ModRecipe(mod);
    //    recipe.AddIngredient(ModContent.ItemType<Phantoplasm>(), 45);
    //    recipe.AddIngredient(ModContent.ItemType<SuperhardmodeBar>(), 40);
    //    recipe.AddIngredient(ModContent.ItemType<SoulofTorture>(), 45);
    //    recipe.AddIngredient(ModContent.ItemType<ElementalExcalibur>());
    //    recipe.AddIngredient(ModContent.ItemType<BerserkerBlade>());
    //    recipe.AddIngredient(ModContent.ItemType<PumpkingsSword>());
    //    recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
    //    recipe.SetResult(this);
    //    recipe.AddRecipe();
    //}
    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        for (int num194 = 0; num194 < 5; num194++)
        {
            float num195 = velocity.X;
            float num196 = velocity.Y;
            num195 += (float)Main.rand.Next(-40, 41) * 0.05f;
            num196 += (float)Main.rand.Next(-40, 41) * 0.05f;
            Projectile.NewProjectile(source, position.X, position.Y, num195, num196, type, damage, knockback, player.whoAmI, 0f, 0f);
        }
        return false;
    }
}
