using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    class BismuthCrown : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bismuth Crown");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.vanity = true;
            item.width = dims.Width;
            item.value = 15000;
            item.height = dims.Height;
        }
    }
}
