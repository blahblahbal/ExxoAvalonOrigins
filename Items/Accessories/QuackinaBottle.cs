using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories
{
    class QuackinaBottle : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Quack in a Bottle");
            Tooltip.SetDefault("Allows the holder to double jump\n'May annoy others'");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.rare = ItemRarityID.Purple;
            item.width = dims.Width;
            item.accessory = true;
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.height = dims.Height;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.Avalon().quackJump = true;
        }
        public override void AddRecipes()
        {
            ModRecipe r = new ModRecipe(mod);
            r.AddIngredient(ModContent.ItemType<Other.Quack>());
            r.AddIngredient(ItemID.CloudinaBottle);
            r.AddTile(TileID.TinkerersWorkbench);
            r.SetResult(this);
            r.AddRecipe();
        }
    }
}
