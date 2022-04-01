using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories
{
    class RubyAmulet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ruby Amulet");
            Tooltip.SetDefault("Increases maximum life by 40");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.rare = ItemRarityID.Green;
            Item.width = dims.Width;
            Item.accessory = true;
            Item.value = Item.sellPrice(0, 0, 50);
            Item.height = dims.Height;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.statLifeMax2 += 40;
        }

        public override void AddRecipes()
        {
            CreateRecipe(1).AddIngredient(ItemID.Ruby, 12).AddIngredient(ItemID.Chain).AddTile(TileID.Anvils).Register();
        }
    }
}
