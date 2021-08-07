using Microsoft.Xna.Framework;
    [AutoloadEquip(EquipType.Legs)]
    class BismuthGreaves : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bismuth Greaves");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Items/BismuthGreaves");
            item.defense = 5;
            item.width = dims.Width;
            item.value = Item.sellPrice(0, 0, 9, 75);
            item.height = dims.Height;
        }
    }