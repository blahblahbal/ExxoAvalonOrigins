using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Blah;

public class BlahsThrow : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Blah's Throw");
        //Tooltip.SetDefault("Shoots out an example yoyo");

        ItemID.Sets.Yoyo[Item.type] = true;
        ItemID.Sets.GamepadExtraRange[Item.type] = 15;
        ItemID.Sets.GamepadSmartQuickReach[Item.type] = true;
    }

    public override void SetDefaults()
    {
        Item.useStyle = ItemUseStyleID.Shoot;
        Item.width = 24;
        Item.height = 24;
        Item.useAnimation = 25;
        Item.useTime = 25;
        Item.shootSpeed = 16f;
        Item.knockBack = 8.5f;
        Item.damage = 221;
        Item.rare = ItemRarityID.Purple;
        Item.DamageType = DamageClass.Melee;
        Item.channel = true;
        Item.noMelee = true;
        Item.noUseGraphic = true;
        Item.UseSound = SoundID.Item1;
        Item.value = Item.sellPrice(1);
        Item.shoot = ModContent.ProjectileType<Projectiles.Melee.BlahsThrow>();
    }

    public override void AddRecipes()
    {
        //ModRecipe recipe = new ModRecipe(mod);
        //recipe.AddIngredient(ModContent.ItemType<ExampleItem>(), 10);
        //recipe.AddIngredient(ItemID.WoodYoyo);
        //recipe.SetResult(this);
        //recipe.AddRecipe();
    }
}