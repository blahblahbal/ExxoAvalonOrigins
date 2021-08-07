using Microsoft.Xna.Framework;
    class BismuthBrick : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bismuth Brick");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Items/BismuthBrick");
            item.autoReuse = true;
            item.consumable = true;
            item.createTile = ModContent.TileType<Tiles.BismuthBrick>();
            item.rare = 0;
            item.width = dims.Width;
            item.useTime = 10;
            item.useTurn = true;
            item.useStyle = 1;
            item.maxStack = 999;
            item.value = 0;
            item.useAnimation = 15;
            item.height = dims.Height;
        }
    }