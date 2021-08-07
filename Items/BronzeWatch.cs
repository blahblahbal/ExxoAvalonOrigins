using Microsoft.Xna.Framework;
    class BronzeWatch : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bronze Watch");
            Tooltip.SetDefault("Tells the time");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Items/BronzeWatch");
            item.width = dims.Width;
            item.accessory = true;
            item.value = 1500;
            item.height = dims.Height;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (player.accWatch < 1) player.accWatch = 1;
        }
    }