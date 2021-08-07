using Microsoft.Xna.Framework;
    [AutoloadEquip(EquipType.Legs)]
    class NickelGreaves : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nickel Greaves");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Items/NickelGreaves");
            item.defense = 3;
            item.width = dims.Width;
            item.value = Item.sellPrice(0, 0, 0, 50);
            item.height = dims.Height;
        }
    }