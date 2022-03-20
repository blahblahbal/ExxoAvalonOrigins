using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories
{
    class StaminaFlower : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Stamina Flower");
            Tooltip.SetDefault("Increases maximum stamina by 60\nAutomatically uses stamina potions when needed");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.rare = ItemRarityID.Pink;
            item.width = dims.Width;
            item.accessory = true;
            item.value = Item.sellPrice(0, 0, 54);
            item.height = dims.Height;
        }
        public override void AddRecipes()
        {
            ModRecipe r = new ModRecipe(mod);
            r.AddIngredient(ModContent.ItemType<Potions.StaminaPotion>());
            r.AddIngredient(ModContent.ItemType<BandofStamina>());
            r.AddIngredient(ItemID.JungleRose);
            r.AddTile(TileID.TinkerersWorkbench);
            r.SetResult(this);
            r.AddRecipe();
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.Avalon().stamFlower = true;
            player.Avalon().statStamMax2 += 60;
        }
    }
}
