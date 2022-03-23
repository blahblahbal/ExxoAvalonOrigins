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
            item.autoReuse = true;
            item.consumable = true;
            item.createTile = ModContent.TileType<Tiles.VenomSpike>();
            item.width = dims.Width;
            item.useTime = 10;
            item.useTurn = true;
            item.maxStack = 999;
            item.value = 50;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useAnimation = 15;
            item.height = dims.Height;
            item.notAmmo = true;
            item.ammo = ItemID.Spike;
            item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().spike = 5;
        }
        public override void AddRecipes()
        {
            ModRecipe r = new ModRecipe(mod);
            r.AddIngredient(ItemID.Spike, 40);
            r.AddIngredient(ItemID.FlaskofVenom);
            r.AddTile(TileID.Anvils);
            r.SetResult(this, 40);
            r.AddRecipe();
        }
    }
}
