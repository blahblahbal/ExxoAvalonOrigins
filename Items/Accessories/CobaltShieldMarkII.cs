using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories
{
    class CobaltShieldMarkII : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cobalt Shield Mark II");
            Tooltip.SetDefault("Increases defense when struck");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.defense = 2;
            item.rare = ItemRarityID.LightRed;
            item.width = dims.Width;
            item.value = 54000;
            item.accessory = true;
            item.height = dims.Height;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.Avalon().incDef = true;
        }
    }
}
