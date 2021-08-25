using Microsoft.Xna.Framework;using Terraria;using Terraria.ID;using Terraria.ModLoader;namespace ExxoAvalonOrigins.Items{
    class TomeoftheRiverSpirits : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tome of the River Spirits");
            Tooltip.SetDefault("Tome\n+15% magic and minion damage\n-5% mana cost");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Items/TomeoftheRiverSpirits");
            item.rare = ItemRarityID.Pink;
            item.width = dims.Width;
            item.value = 15000;
            item.height = dims.Height;            item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().tome = true;        }        public override void UpdateAccessory(Player player, bool hideVisual)        {            player.magicDamage += 0.15f;            player.minionDamage += 0.15f;            player.manaCost -= 0.05f;        }

        public override void AddRecipes()        {            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<MeditationsFlame>());
            recipe.AddIngredient(ModContent.ItemType<EternitysMoon>());
            recipe.AddIngredient(ItemID.FallenStar, 20);
            recipe.AddIngredient(ModContent.ItemType<MysticalTomePage>());
            recipe.AddTile(ModContent.TileType<Tiles.TomeForge>());
            recipe.SetResult(this);
            recipe.AddRecipe();        }    }}