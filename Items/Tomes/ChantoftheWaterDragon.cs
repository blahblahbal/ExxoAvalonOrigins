using ExxoAvalonOrigins.Items.Material;
using ExxoAvalonOrigins.Items.Placeable.Bar;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tomes
{
    class ChantoftheWaterDragon : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Chant of the Water Dragon");
            Tooltip.SetDefault("Tome\n+20% magic damage");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.rare = ItemRarityID.Yellow;
            Item.width = dims.Width;
            Item.value = 150000;
            Item.height = dims.Height;
            Item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().tome = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage(DamageClass.Magic) += 0.2f;
        }

        public override void AddRecipes()
        {
            CreateRecipe(1).AddIngredient(ModContent.ItemType<DragonOrb>()).AddIngredient(ModContent.ItemType<OblivionBar>(), 25).AddIngredient(ModContent.ItemType<SoulofBlight>(), 30).AddIngredient(ItemID.FallenStar, 100).AddIngredient(ModContent.ItemType<MysticalTomePage>(), 5).AddTile(ModContent.TileType<Tiles.TomeForge>()).Register();
        }
    }
}
