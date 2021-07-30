using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;namespace ExxoAvalonOrigins.Items{
    class BerserkerBlade : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Berserker Blade");
            Tooltip.SetDefault("'Go berserk!'");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Items/BerserkerBlade");
            item.damage = 166;
            item.autoReuse = true;
            item.UseSound = SoundID.Item1;
            item.useTurn = true;
            item.scale = 1f;
            item.rare = 8;
            item.width = dims.Width;
            item.useTime = 10;
            item.knockBack = 5f;
            item.melee = true;
            item.useStyle = 1;
            item.value = Item.sellPrice(0, 12);
            item.useAnimation = 10;
            item.height = dims.Height;
        }
        public override Color? GetAlpha(Color lightColor)
        {
            return new Color(255, 255, 255, 255);
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<BerserkerBar>(), 40);
            recipe.AddIngredient(ModContent.ItemType<VoraylzumKatana>());
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<BerserkerBar>(), 40);
            recipe.AddIngredient(ModContent.ItemType<UnvolanditeGreatsword>());
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }}