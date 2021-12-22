using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    class ZincChainmail : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Zinc Chainmail");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.defense = 5;
            item.width = dims.Width;
            item.value = Item.sellPrice(0, 0, 1, 75);
            item.height = dims.Height;
        }
    }
}
