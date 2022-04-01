using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories
{
    class DiamondAmulet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Diamond Amulet");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.rare = ItemRarityID.Green;
            Item.width = dims.Width;
            Item.accessory = true;
            Item.value = Item.sellPrice(0, 0, 50);
            Item.height = dims.Height;
            Item.defense = 5;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {

        }

        public override void AddRecipes()
        {
            CreateRecipe(1).AddIngredient(ItemID.Diamond, 12).AddIngredient(ItemID.Chain).AddTile(TileID.Anvils).Register();
        }
    }
}
