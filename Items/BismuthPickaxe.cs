using Microsoft.Xna.Framework;
    class BismuthPickaxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bismuth Pickaxe");
        }
        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Items/BismuthPickaxe");
            item.UseSound = SoundID.Item1;
            item.damage = 6;
            item.autoReuse = true;
            item.useTurn = true;
            item.scale = 1f;
            item.pick = 62;
            item.width = dims.Width;
            item.useTime = 10;
            item.knockBack = 2f;
            item.melee = true;
            item.useStyle = 1;
            item.value = 4500;
            item.useAnimation = 14;
            item.height = dims.Height;
        }
    }