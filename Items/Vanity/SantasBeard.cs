using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Vanity
{
    [AutoloadEquip(EquipType.Face)]
    class SantasBeard : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Santa's Beard");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.rare = ItemRarityID.Lime;
            item.width = dims.Width;
            item.maxStack = 1;
            item.value = Item.buyPrice(0, 40, 0, 0);
            item.accessory = true;
            item.vanity = true;
            item.height = dims.Height;
        }
    }
}
