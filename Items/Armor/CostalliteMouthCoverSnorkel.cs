using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    class CostalliteMouthCoverSnorkel : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Costallite Mouth Cover Snorkel");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.rare = ItemRarityID.Cyan;
            item.width = dims.Width;
            item.defense = 3;
            item.value = Item.sellPrice(0, 1, 50, 0);
            item.height = dims.Height;
        }

        public override void DrawHair(ref bool drawHair, ref bool drawAltHair)
        {
            drawHair = (drawAltHair = true);
        }
    }
}
