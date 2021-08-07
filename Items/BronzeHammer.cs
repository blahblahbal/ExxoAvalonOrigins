using Microsoft.Xna.Framework;
    class BronzeHammer : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bronze Hammer");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Items/BronzeHammer");
            item.damage = 7;
            item.autoReuse = true;
            item.hammer = 39;
            item.useTurn = true;
            item.scale = 1.2f;
            item.width = dims.Width;
            item.useTime = 21;
            item.knockBack = 4.5f;
            item.melee = true;
            item.useStyle = 1;
            item.value = 700;
            item.useAnimation = 31;
            item.height = dims.Height;
        }
    }