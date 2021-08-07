using Microsoft.Xna.Framework;
    [AutoloadEquip(EquipType.Legs)]
    class BronzeGreaves : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bronze Greaves");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Items/BronzeGreaves");
            item.defense = 2;
            item.width = dims.Width;
            item.value = Item.sellPrice(0, 0, 0, 40);
            item.height = dims.Height;
        }
    }