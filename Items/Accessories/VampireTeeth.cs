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
            Item.rare = ItemRarityID.Yellow;
            Item.width = dims.Width;
            Item.accessory = true;
            Item.value = Item.sellPrice(0, 10, 0, 0);
            Item.height = dims.Height;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.Avalon().vampireTeeth = true;
        }
    }
}
