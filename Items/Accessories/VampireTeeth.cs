using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories
{
    class VampireTeeth : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Vampire Teeth");
            Tooltip.SetDefault("Grants the ability for true melee attacks to lifesteal");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.rare = ItemRarityID.Yellow;
            item.width = dims.Width;
            item.accessory = true;
            item.value = Item.sellPrice(0, 10, 0, 0);
            item.height = dims.Height;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.Avalon().vampireTeeth = true;
        }
    }
}
