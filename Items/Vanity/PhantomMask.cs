using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Vanity
{
    [AutoloadEquip(EquipType.Head)]
    class PhantomMask : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Phantom Mask");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.rare = ItemRarityID.Cyan;
            Item.width = dims.Width;
            Item.vanity = true;
            Item.value = Item.sellPrice(0, 1, 10, 0);
            Item.height = dims.Height;
        }
    }
}
