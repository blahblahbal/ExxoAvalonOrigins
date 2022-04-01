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
            Item.rare = ItemRarityID.Lime;
            Item.width = dims.Width;
            Item.maxStack = 1;
            Item.value = Item.buyPrice(0, 40, 0, 0);
            Item.accessory = true;
            Item.vanity = true;
            Item.height = dims.Height;
        }
    }
}
