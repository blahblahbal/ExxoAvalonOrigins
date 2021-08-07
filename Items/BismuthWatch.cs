using Microsoft.Xna.Framework;
    class BismuthWatch : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bismuth Watch");
            Tooltip.SetDefault("Tells the time");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Items/BismuthWatch");
            item.width = dims.Width;
            item.rare = 1;
            item.accessory = true;
            item.value = 1500;
            item.height = dims.Height;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (player.accWatch < 3) player.accWatch = 3;
        }
    }