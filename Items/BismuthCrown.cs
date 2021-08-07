using Microsoft.Xna.Framework;
    [AutoloadEquip(EquipType.Head)]
    class BismuthCrown : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bismuth Crown");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Items/BismuthCrown");
            item.vanity = true;
            item.width = dims.Width;
            item.value = 15000;
            item.height = dims.Height;
        }
    }