using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Vanity
{
    [AutoloadEquip(EquipType.Legs)]
    class HellArmoredGreaves : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hell Armored Greaves");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.rare = ItemRarityID.Yellow;
            item.width = dims.Width;
            item.vanity = true;
            item.value = Item.sellPrice(0, 0, 90, 0);
            item.height = dims.Height;
        }
    }
}
