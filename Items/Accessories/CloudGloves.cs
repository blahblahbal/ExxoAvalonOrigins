using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories
{
    class CloudGloves : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cloud Glove");
            Tooltip.SetDefault("The wearer can place blocks and walls in midair");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.rare = ItemRarityID.LightRed;
            Item.width = dims.Width;
            Item.accessory = true;
            Item.value = Item.sellPrice(0, 1, 0, 0);
            Item.height = dims.Height;
            Item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().updateInvisibleVanity = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.Avalon().cloudGloves = true;
        }
        public override void UpdateVanity(Player player, EquipType type)
        {
            player.Avalon().cloudGloves = true;
        }
        public override void AddRecipes()
        {
            CreateRecipe(1).AddIngredient(ItemID.Silk, 15).AddIngredient(ItemID.Cloud, 25).AddIngredient(ItemID.SoulofFlight, 5).AddRecipeGroup("ExxoAvalonOrigins:GoldBar", 5).AddIngredient(ItemID.SunplateBlock, 10).AddTile(TileID.TinkerersWorkbench).Register();
        }
    }
}
