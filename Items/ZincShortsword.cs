using Microsoft.Xna.Framework;
    class ZincShortsword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Zinc Shortsword");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Items/ZincShortsword");
            item.damage = 11;
            item.useTurn = true;
            item.scale = 1f;
            item.width = dims.Width;
            item.useTime = 10;
            item.knockBack = 4f;
            item.melee = true;
            item.useStyle = 3;
            item.value = 1700;
            item.useAnimation = 10;
            item.height = dims.Height;
        }
    }