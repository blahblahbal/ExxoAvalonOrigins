using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Placeable.Tile
{
    class PoisonSpike : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Poison Spike");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.autoReuse = true;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<Tiles.PoisonSpike>();
            Item.rare = ItemRarityID.Green;
            Item.width = dims.Width;
            Item.useTime = 10;
            Item.useTurn = true;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.maxStack = 999;
            Item.value = 0;
            Item.useAnimation = 15;
            Item.height = dims.Height;
            Item.notAmmo = true;
            Item.ammo = ItemID.Spike;
            Item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().spike = 6;
        }
        public override void AddRecipes()
        {
            CreateRecipe(20).AddIngredient(ItemID.Spike, 20).AddIngredient(ItemID.Stinger).AddTile(TileID.Anvils).Register();
            CreateRecipe(20).AddIngredient(ItemID.Spike, 20).AddIngredient(ModContent.ItemType<Material.MosquitoProboscis>()).AddTile(TileID.Anvils).Register();
        }
    }
}
