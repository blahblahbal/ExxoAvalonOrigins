using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tools
{
    class SonicScrewdriverMkI : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sonic Screwdriver Mk I");
            Tooltip.SetDefault("Reveals treasures, ores, and mobs");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.rare = ItemRarityID.Orange;
            Item.width = dims.Width;
            Item.useTime = 70;
            Item.value = Item.sellPrice(0, 1, 0, 0);
            Item.useStyle = ItemUseStyleID.Thrust;
            Item.useAnimation = 70;
            Item.height = dims.Height;
            Item.UseSound = Mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/SonicScrewdriver");
        }
    }
}
