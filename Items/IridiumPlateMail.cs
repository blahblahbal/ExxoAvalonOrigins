using Microsoft.Xna.Framework;
    [AutoloadEquip(EquipType.Body)]
    class IridiumPlateMail : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Iridium Plate Mail");
            Tooltip.SetDefault("Increases maximum mana by 50");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Items/IridiumPlateMail");
            item.defense = 9;
            item.rare = 4;
            item.width = dims.Width;
            item.value = Item.sellPrice(0, 1, 40, 0);
            item.height = dims.Height;
        }
        public override void UpdateEquip(Player player)
        {
            player.statManaMax2 += 50;
        }
    }