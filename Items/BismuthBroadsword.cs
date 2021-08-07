using Microsoft.Xna.Framework;
    class BismuthBroadsword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bismuth Broadsword");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Items/BismuthBroadsword");
            item.damage = 16;
            item.useTurn = true;
            item.scale = 1.2f;
            item.width = dims.Width;
            item.useTime = 18;
            item.knockBack = 5.2f;
            item.melee = true;
            item.useStyle = 1;
            item.value = 4500;
            item.useAnimation = 18;
            item.height = dims.Height;
        }
    }