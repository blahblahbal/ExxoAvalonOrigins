using ExxoAvalonOrigins.Items.Material;
using ExxoAvalonOrigins.Items.Placeable.Bar;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tomes
{
    class TheOasisRemembered : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Oasis Remembered");
            Tooltip.SetDefault("Tome\n20% increased minion damage and knockback");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.rare = ItemRarityID.Yellow;
            Item.width = dims.Width;
            Item.value = Item.sellPrice(0, 0, 40);
            Item.height = dims.Height;
            Item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().tome = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage(DamageClass.Summon) += 0.2f;
            player.minionKB += 0.2f;
        }

        public override void AddRecipes()
        {
            CreateRecipe(1).AddIngredient(ModContent.ItemType<DragonOrb>()).AddIngredient(ModContent.ItemType<HydrolythBar>(), 25).AddIngredient(ModContent.ItemType<SoulofBlight>(), 10).AddIngredient(ModContent.ItemType<MysticalTomePage>(), 5).AddTile(ModContent.TileType<Tiles.TomeForge>()).Register();
        }
    }
}
