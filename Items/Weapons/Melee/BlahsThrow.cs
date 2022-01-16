using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Melee
{
    public class BlahsThrow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blah's Throw");
            //Tooltip.SetDefault("Shoots out an example yoyo");

            ItemID.Sets.Yoyo[item.type] = true;
            ItemID.Sets.GamepadExtraRange[item.type] = 15;
            ItemID.Sets.GamepadSmartQuickReach[item.type] = true;
        }

        public override void SetDefaults()
        {
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.width = 24;
            item.height = 24;
            item.useAnimation = 25;
            item.useTime = 25;
            item.shootSpeed = 16f;
            item.knockBack = 8.5f;
            item.damage = 221;
            item.rare = ItemRarityID.Purple;
            item.melee = true;
            item.channel = true;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.UseSound = SoundID.Item1;
            item.value = Item.sellPrice(1);
            item.shoot = ModContent.ProjectileType<Projectiles.BlahsThrow>();
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
}
