using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor
{
    [AutoloadEquip(EquipType.Legs)]
    class ZincGreaves : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Zinc Greaves");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.defense = 4;
            item.width = dims.Width;
            item.value = Item.sellPrice(0, 0, 1, 75);
            item.height = dims.Height;
        }
    }
}
