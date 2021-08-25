using Microsoft.Xna.Framework;using Terraria;using Terraria.DataStructures;
using Terraria.ID;using Terraria.ModLoader;
namespace ExxoAvalonOrigins.Items{
    class DragonOrb : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dragon Orb");            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 8));
            ItemID.Sets.ItemNoGravity[item.type] = true;
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Items/DragonOrb");
            item.rare = ItemRarityID.Green;
            item.width = dims.Width;
            item.value = Item.sellPrice(0, 0, 2, 0);
            item.maxStack = 999;
            item.height = 26;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<ElementDust>(), 3);
            recipe.AddIngredient(ModContent.ItemType<ElementDiamond>(), 2);
            recipe.AddIngredient(ModContent.ItemType<RubybeadHerb>(), 6);
            recipe.AddIngredient(ModContent.ItemType<DewOrb>(), 3);
            recipe.AddIngredient(ModContent.ItemType<StrongVenom>(), 5);
            recipe.AddIngredient(ModContent.ItemType<MysticalTotem>());
            recipe.AddIngredient(ModContent.ItemType<DewofHerbs>(), 3);
            recipe.AddIngredient(ModContent.ItemType<MysticalClaw>(), 4);
            recipe.AddTile(ModContent.TileType<Tiles.TomeForge>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }}