using Microsoft.Xna.Framework;
    class IridiumBrick : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Iridium Brick");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Items/IridiumBrick");
            item.autoReuse = true;
            item.consumable = true;
            item.createTile = ModContent.TileType<Tiles.IridiumBrick>();
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