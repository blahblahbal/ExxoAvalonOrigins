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
            Item.defense = 2;
            Item.rare = ItemRarityID.LightRed;
            Item.width = dims.Width;
            Item.value = 54000;
            Item.accessory = true;
            Item.height = dims.Height;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.Avalon().incDef = true;
        }
    }
}
