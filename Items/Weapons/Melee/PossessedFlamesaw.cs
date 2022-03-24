using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Melee
{
    class PossessedFlamesaw : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Possessed Flamesaw");
            Tooltip.SetDefault("Can chop trees instantly");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.damage = 95;
            item.noUseGraphic = true;
            item.shootSpeed = 14f;
            item.noMelee = true;
            item.rare = ItemRarityID.Red;
            item.width = dims.Width;
            item.knockBack = 9f;
            item.useTime = 15;
            item.shoot = ModContent.ProjectileType<Projectiles.Melee.PossessedFlamesaw>();
            item.melee = true;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.value = Item.sellPrice(0, 40, 0, 0);
            item.useAnimation = 15;
            item.height = dims.Height;
            item.UseSound = SoundID.Item1;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PossessedHatchet);
            recipe.AddIngredient(ItemID.AdamantiteChainsaw);
            recipe.AddIngredient(ModContent.ItemType<Material.SoulofBlight>(), 20);
            recipe.AddIngredient(ItemID.CursedFlame, 50);
            recipe.AddIngredient(ItemID.LivingFireBlock, 160);
            recipe.AddTile(ModContent.TileType<Tiles.SolariumAnvil>());
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PossessedHatchet);
            recipe.AddIngredient(ItemID.TitaniumChainsaw);
            recipe.AddIngredient(ModContent.ItemType<Material.SoulofBlight>(), 20);
            recipe.AddIngredient(ItemID.CursedFlame, 50);
            recipe.AddIngredient(ItemID.LivingFireBlock, 160);
            recipe.AddTile(ModContent.TileType<Tiles.SolariumAnvil>());
            recipe.SetResult(this);
            recipe.AddRecipe();
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PossessedHatchet);
            recipe.AddIngredient(ModContent.ItemType<Tools.TroxiniumChainsaw>());
            recipe.AddIngredient(ModContent.ItemType<Material.SoulofBlight>(), 20);
            recipe.AddIngredient(ItemID.CursedFlame, 50);
            recipe.AddIngredient(ItemID.LivingFireBlock, 160);
            recipe.AddTile(ModContent.TileType<Tiles.SolariumAnvil>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
