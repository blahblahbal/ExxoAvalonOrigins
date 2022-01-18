using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    class CostalliteSnorkel : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Costallite Snorkel");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.rare = ItemRarityID.Green;
            item.width = dims.Width;
            item.defense = 4;
            item.value = Item.sellPrice(0, 1, 50, 0);
            item.height = dims.Height;
        }

        public override void DrawHair(ref bool drawHair, ref bool drawAltHair)
        {
            drawHair = (drawAltHair = true);
        }
    }
}
