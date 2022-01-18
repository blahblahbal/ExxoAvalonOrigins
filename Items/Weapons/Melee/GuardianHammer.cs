using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Melee
{
    class GuardianHammer : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Guardian Hammer");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.damage = 200;
            item.noUseGraphic = true;
            item.shootSpeed = 16f;
            item.rare = ItemRarityID.Cyan;
            item.noMelee = true;
            item.width = dims.Width;
            item.useTime = 32;
            item.knockBack = 10f;
            item.shoot = ModContent.ProjectileType<Projectiles.GuardianHammer2>();
            item.melee = true;
            item.value = Item.sellPrice(0, 25, 0, 0);
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useAnimation = 32;
            item.height = dims.Height;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PaladinsHammer);
            recipe.AddIngredient(ModContent.ItemType<Material.SoulofBlight>(), 20);
            recipe.AddIngredient(ItemID.Ectoplasm, 15);
            recipe.AddTile(ModContent.TileType<Tiles.SolariumAnvil>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
