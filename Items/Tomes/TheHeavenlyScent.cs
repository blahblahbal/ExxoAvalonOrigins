using ExxoAvalonOrigins.Items.Material;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tomes
{
    class TheHeavenlyScent : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Heavenly Scent");
            Tooltip.SetDefault("Tome\n+2 life regen");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.rare = ItemRarityID.Lime;
            Item.width = dims.Width;
            Item.value = 150000;
            Item.height = dims.Height;
            Item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().tome = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.lifeRegen += 2;
        }

        public override void AddRecipes()
        {
            CreateRecipe(1).AddIngredient(ModContent.ItemType<RubybeadHerb>(), 3).AddIngredient(ModContent.ItemType<Sandstone>(), 3).AddIngredient(ItemID.LesserHealingPotion, 5).AddIngredient(ItemID.BandofRegeneration).AddIngredient(ModContent.ItemType<MysticalTomePage>(), 3).AddTile(ModContent.TileType<Tiles.TomeForge>()).Register();
        }
    }
}
