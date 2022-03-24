using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Placeable.Crafting
{
    class Anvenalforge : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Anvenalforge");
            Tooltip.SetDefault("Used to craft almost anything");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.autoReuse = true;
            item.consumable = true;
            item.createTile = ModContent.TileType<Tiles.Anvenalforge>();
            item.rare = ItemRarityID.Purple;
            item.width = dims.Width;
            item.useTurn = true;
            item.useTime = 10;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.maxStack = 99;
            item.value = 100000;
            item.useAnimation = 15;
            item.height = dims.Height;
        }
        public override void AddRecipes()
        {
            ModRecipe r = new ModRecipe(mod);
            r.AddIngredient(ModContent.ItemType<CaesiumForge>());
            r.AddIngredient(ModContent.ItemType<SolariumAnvil>());
            r.AddRecipeGroup("ExxoAvalonOrigins:WorkBenches");
            r.AddIngredient(ModContent.ItemType<DemonAltar>());
            r.AddIngredient(ModContent.ItemType<HallowedAltar>());
            r.AddIngredient(ItemID.LunarCraftingStation);
            r.AddIngredient(ModContent.ItemType<Material.SoulofTorture>(), 10);
            r.AddTile(TileID.TinkerersWorkbench);
            r.SetResult(this);
            r.AddRecipe();

            r = new ModRecipe(mod);
            r.AddIngredient(ModContent.ItemType<CaesiumForge>());
            r.AddIngredient(ModContent.ItemType<SolariumAnvil>());
            r.AddRecipeGroup("ExxoAvalonOrigins:WorkBenches");
            r.AddIngredient(ModContent.ItemType<CrimsonAltar>());
            r.AddIngredient(ModContent.ItemType<HallowedAltar>());
            r.AddIngredient(ItemID.LunarCraftingStation);
            r.AddIngredient(ModContent.ItemType<Material.SoulofTorture>(), 10);
            r.AddTile(TileID.TinkerersWorkbench);
            r.SetResult(this);
            r.AddRecipe();

            r = new ModRecipe(mod);
            r.AddIngredient(ModContent.ItemType<CaesiumForge>());
            r.AddIngredient(ModContent.ItemType<SolariumAnvil>());
            r.AddRecipeGroup("ExxoAvalonOrigins:WorkBenches");
            r.AddIngredient(ModContent.ItemType<IckyAltar>());
            r.AddIngredient(ModContent.ItemType<HallowedAltar>());
            r.AddIngredient(ItemID.LunarCraftingStation);
            r.AddIngredient(ModContent.ItemType<Material.SoulofTorture>(), 10);
            r.AddTile(TileID.TinkerersWorkbench);
            r.SetResult(this);
            r.AddRecipe();
        }
    }
}
