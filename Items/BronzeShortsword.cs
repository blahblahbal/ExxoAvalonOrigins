using Microsoft.Xna.Framework;
    class BronzeShortsword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bronze Shortsword");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Items/BronzeShortsword");
            item.damage = 7;
            item.useTurn = true;
            item.scale = 1f;
            item.width = dims.Width;
            item.useTime = 13;
            item.knockBack = 5.2f;
            item.melee = true;
            item.useStyle = 3;
            item.value = 900;
            item.useAnimation = 13;
            item.height = dims.Height;
        }
    }