using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor
{
    [AutoloadEquip(EquipType.Legs)]
    class BismuthGreaves : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bismuth Greaves");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.defense = 5;
            item.width = dims.Width;
            item.value = Item.sellPrice(0, 0, 9, 75);
            item.height = dims.Height;
        }
    }
}
