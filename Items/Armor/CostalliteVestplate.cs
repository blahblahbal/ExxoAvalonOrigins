using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    class CostalliteVestplate : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Costallite Vestplate");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.rare = ItemRarityID.Green;
            Item.width = dims.Width;
            Item.defense = 10;
            Item.value = Item.sellPrice(0, 1, 50, 0);
            Item.height = dims.Height;
        }
    }
}
