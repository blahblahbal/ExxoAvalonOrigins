using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Placeable.Tile
{
    class DemonSpikeScale : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Demon Spikescale");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.autoReuse = true;
            item.consumable = true;
            item.createTile = ModContent.TileType<Tiles.DemonSpikescale>();
            item.rare = ItemRarityID.LightRed;
            item.width = dims.Width;
            item.useTime = 10;
            item.useTurn = true;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.maxStack = 999;
            item.value = Item.sellPrice(0, 0, 1, 0);
            item.useAnimation = 15;
            item.height = dims.Height;
            item.notAmmo = true;
            item.ammo = ItemID.Spike;
            item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().spike = 1;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Spike);
            recipe.AddIngredient(ItemID.ShadowScale);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
