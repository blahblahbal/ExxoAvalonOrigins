using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Placeable.Tile
{
    class VenomSpike : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Venom Spike");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.autoReuse = true;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<Tiles.VenomSpike>();
            Item.width = dims.Width;
            Item.useTime = 10;
            Item.useTurn = true;
            Item.maxStack = 999;
            Item.value = 50;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useAnimation = 15;
            Item.height = dims.Height;
            Item.notAmmo = true;
            Item.ammo = ItemID.Spike;
            Item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().spike = 5;
        }
        public override void AddRecipes()
        {
            CreateRecipe(40).AddIngredient(ItemID.Spike, 40).AddIngredient(ItemID.FlaskofVenom).AddTile(TileID.Anvils).Register();
        }
    }
}
