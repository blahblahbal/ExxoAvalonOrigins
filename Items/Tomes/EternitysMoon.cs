using ExxoAvalonOrigins.Items.Material;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tomes
{
    class EternitysMoon : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Eternity's Moon");
            Tooltip.SetDefault("Tome\n+20 mana, -5% mana cost");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.rare = ItemRarityID.Green;
            Item.width = dims.Width;
            Item.value = 15000;
            Item.height = dims.Height;
            Item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().tome = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.statManaMax2 += 20;
            player.manaCost -= 0.05f;
        }

        public override void AddRecipes()
        {
            CreateRecipe(1).AddIngredient(ItemID.FallenStar, 10).AddIngredient(ModContent.ItemType<Gravel>(), 15).AddIngredient(ModContent.ItemType<MysticalClaw>(), 2).AddIngredient(ModContent.ItemType<MysticalTomePage>()).AddTile(ModContent.TileType<Tiles.TomeForge>()).Register();
        }
    }
}
