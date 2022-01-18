using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Vanity
{
    [AutoloadEquip(EquipType.Head)]
    class BacteriumPrimeMask : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bacterium Prime Mask");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.rare = ItemRarityID.Blue;
            item.width = dims.Width;
            item.vanity = true;
            item.value = Item.sellPrice(0, 2, 0, 0);
            item.height = dims.Height;
        }
    }
}
