using Microsoft.Xna.Framework;using Terraria;using Terraria.ID;using Terraria.ModLoader;namespace ExxoAvalonOrigins.Items{
    class TaleoftheRedLotus : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tale of the Red Lotus");
            Tooltip.SetDefault("Tome\n+5% ranged damage\n+20 HP");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Items/TaleoftheRedLotus");
            item.rare = ItemRarityID.LightRed;
            item.width = dims.Width;
            item.value = 5000;
            item.height = dims.Height;            item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().tome = true;        }        public override void UpdateAccessory(Player player, bool hideVisual)        {            player.rangedDamage += 0.05f;            player.statLifeMax2 += 20;        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<DewOrb>(), 6);
            recipe.AddIngredient(ModContent.ItemType<CarbonSteel>(), 5);
            recipe.AddIngredient(ModContent.ItemType<Sandstone>(), 10);
            recipe.AddIngredient(ItemID.FallenStar, 15);
            recipe.AddIngredient(ModContent.ItemType<MysticalTomePage>(), 4);
            recipe.AddTile(ModContent.TileType<Tiles.TomeForge>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }    }}