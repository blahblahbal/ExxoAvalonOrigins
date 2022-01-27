using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories
{
    class QuackinaBalloon : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Quack in a Balloon");
            Tooltip.SetDefault("Allows the holder to double jump\nIncreases jump height\n'May annoy others'");
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
            player.jumpBoost = true;
        }
        public override void AddRecipes()
        {
            ModRecipe r = new ModRecipe(mod);
            r.AddIngredient(ModContent.ItemType<QuackinaBottle>());
            r.AddIngredient(ItemID.ShinyRedBalloon);
            r.AddTile(TileID.TinkerersWorkbench);
            r.SetResult(this);
            r.AddRecipe();
        }
    }
}
